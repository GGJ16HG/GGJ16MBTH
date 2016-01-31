using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

//! This class draw a color picker. The data and the ui are unified.
//! The object handle the update of each textures drawn in the ui and 
//! also the value of the current color.
public class ColorPicker
{
	private Color current_RGB_color_; // Current RGB color
	private Color current_color_; // Current Saturated color
	private float saturation_ = 0.0F;

	private Texture2D hue_luminance_tex_; // Static texture

	// Dynamic textures
	private Texture2D saturation_tex_;
	private Texture2D thumbnail_tex_;
	
	private GameObject go_to_notify_;
	private String tweak_name_;

	public ColorPicker(Color color, Texture2D saturated_colors, GameObject go_to_notify, String tweak_name)
	{
		current_RGB_color_ = color;

		current_color_ = color;

		hue_luminance_tex_ = saturated_colors;
		go_to_notify_ = go_to_notify;
		tweak_name_ = tweak_name;

		thumbnail_tex_= new Texture2D(14, 14, TextureFormat.RGB24, false);
		saturation_tex_ = new Texture2D(94, 8, TextureFormat.RGB24, false);
		saturation_tex_.wrapMode = TextureWrapMode.Clamp;

		updateSaturationTexture();
		updateThumbnailTexture();
	}

	public String getTweakName()
	{
		return tweak_name_;
	}

	public Color getColorRGB()
	{
		return current_RGB_color_;
	}

	private void updateSaturationTexture()
	{    
		//Generate Saturation Texture
		float max = Math.Max(Math.Max(current_color_.r,current_color_.g),current_color_.b);
		Color maxColor = new Color(max,max,max);
		for(int y=0; y  < saturation_tex_.height; ++y)
		{
			for(int x=0; x  < saturation_tex_.width; ++x) 
			{	
				saturation_tex_.SetPixel(x, y, Color.Lerp(current_color_, maxColor, ((float)x/saturation_tex_.width)));
			}
		}
		saturation_tex_.Apply();	
	}

	private void updateThumbnailTexture()
	{
		current_RGB_color_ = saturation_tex_.GetPixel((int)(saturation_*saturation_tex_.width),0);
		for(int y=0; y  < thumbnail_tex_.height; ++y)
		{
			for(int x=0; x  < thumbnail_tex_.width; ++x) 
			{	
				thumbnail_tex_.SetPixel(x, y, current_RGB_color_);
			}
		}
		thumbnail_tex_.Apply();
		
		go_to_notify_.SendMessage("ColorPickerColorChange",this);
	}

	public void drawUI(Rect position)
	{
		if(GUI.RepeatButton(position,hue_luminance_tex_))
		{
			Vector2 pickpos = Event.current.mousePosition;
			int aaa = Convert.ToInt32(pickpos.x-position.x);
			int bbb = Convert.ToInt32(pickpos.y-position.y);
			current_color_ = hue_luminance_tex_.GetPixel(aaa,25-bbb);
			updateSaturationTexture();
			updateThumbnailTexture();
		}
		
		Rect saturation_position = new Rect(position.x,position.y+32,100,14);
		if(GUI.RepeatButton(saturation_position, saturation_tex_))
		{
			Vector2 pickpos = Event.current.mousePosition;
			saturation_ = Convert.ToInt32(pickpos.x-(saturation_position.x)) / (float)saturation_tex_.width;
			updateThumbnailTexture();	
		}

		Rect thumbnail_position = new Rect(position.x+105,position.y+5,20,20);
		GUI.Box(thumbnail_position, thumbnail_tex_);
	}
};

//! This class collects all parameters from the substnces applied on the character.
//! It displays these parameters with the corresponding GUI widget using a custom GUIskin.
public class Customize : MonoBehaviour {

	public Vector2 sizeSlider = new Vector2(100,30);
	public Vector2 sizeLabel = new Vector2(40,30);
	public int spaceBetweenSliders = 3;
	public Vector2 offset = new Vector2(0,0);

	public GUISkin customSkin;
	public Texture2D colorPicker;
	public Texture2D Panel;
	
	private ProceduralMaterial Body;
	private	ProceduralMaterial Head;
	
	ArrayList TweaksList = new ArrayList(); //! Tweaks list.
	
	//! Color pickers for the color tweaks
	private Dictionary<String,ColorPicker> colorPickers = new Dictionary<String,ColorPicker>();
	
	//! Current values of all the tweak (minus the color tweaks)
	private Dictionary<String,Vector4> current_tweak_ui_value = new Dictionary<String,Vector4>();
			
	//! Tweaks Display
	private Vector2 scrollViewVector = Vector2.zero;
	private Rect TweakRect;
	
	//! For Camera control 	
	public bool Zoom = false;
	public Camera cam;
		
	//! For Enum Tweaks display 		
	private List<Vector2> scrollPosEnumList = new List<Vector2>();
	private int EnumCount = 0;
	
	public GameObject Mesh;
	
	//! Get the substances at launch
	public void Awake()
	{ 
		Body = Mesh.renderer.sharedMaterials[0] as ProceduralMaterial;
		Head = Mesh.renderer.sharedMaterials[1] as ProceduralMaterial;
		UpdateSubstances();
	}

	//! Draw the tweaks window and other buttons
	public void OnGUI()
	{
		GUI.skin = customSkin;
		DrawTweaks();
		//! Character rotation
		if(GUI.RepeatButton(new Rect(Screen.width/2-80,Screen.height-70,80,60),"","TurnLeftStyle"))
		{
			transform.Rotate(Vector3.up * Time.deltaTime*100);
		}
		//! Camera controls
		if(GUI.Button(new Rect(Screen.width/2+15,Screen.height-70,60,60),"","ZoomStyle"))
		{
			if (!Zoom && !cam.animation.isPlaying)
			{
				cam.animation["Zoom"].speed = 1;
				cam.animation.Play();
				Zoom = true;
			}
			else if (Zoom && !cam.animation.isPlaying)
			{
				cam.animation["Zoom"].speed = -1;
				cam.animation["Zoom"].time = cam.animation["Zoom"].length;
				cam.animation.Play();
				Zoom = false;
			}
		}
		if(GUI.RepeatButton(new Rect(Screen.width/2+90,Screen.height-70,80,60),"","TurnRightStyle"))
		{
			transform.Rotate(Vector3.up * Time.deltaTime*-100);
		}
	}

	public void Update()
	{
		
	}

	
	//! Callback called each time a color picker is updated
	private void ColorPickerColorChange(ColorPicker color_picker)
	{
		if (Body.HasProceduralProperty(color_picker.getTweakName()))
		{
			Body.SetProceduralColor(color_picker.getTweakName(),color_picker.getColorRGB());
			Body.RebuildTextures();
		}
		if (Head.HasProceduralProperty(color_picker.getTweakName()))
		{
			Head.SetProceduralColor(color_picker.getTweakName(),color_picker.getColorRGB());
			Head.RebuildTextures();
		}
	}
	
	

	private void UpdateSubstances()
	{
		// Here we build 3 lists
		// One with the color pickers (one for each color tweak in the substance)
		// One with the ProceduralPropertyDescription of the tweaks we want to tweak.
		// And one with the current gui value of each tweaks (except those for the color tweaks). 
		// This list is necessary since we don't want to synch the ui with the substance computing.
		TweaksList.Clear();
		EnumCount = 0;
		scrollPosEnumList.Clear();
		colorPickers.Clear();
		current_tweak_ui_value.Clear();
		foreach (ProceduralMaterial sub in Mesh.renderer.sharedMaterials)
		{
			// We add every tweak to our lists unless they are already in it 
			// to avoid GUI duplication if multiple substances share the same tweaks.
			foreach( ProceduralPropertyDescription tweak in sub.GetProceduralPropertyDescriptions())
			{
				if(tweak.type == ProceduralPropertyType.Color3 || tweak.type == ProceduralPropertyType.Color4 && !colorPickers.ContainsKey(tweak.name))
				{
					colorPickers.Add(tweak.name,new ColorPicker(sub.GetProceduralColor(tweak.name),colorPicker,this.gameObject,tweak.name));
				}
				else if (!current_tweak_ui_value.ContainsKey(tweak.name))
				{
					Vector4 value = new Vector4();
					if (tweak.type == ProceduralPropertyType.Float)
					{
						value.x = sub.GetProceduralFloat(tweak.name);
					}
					else if (tweak.type == ProceduralPropertyType.Boolean)
					{
						value.x = sub.GetProceduralBoolean(tweak.name) == true ? 1.0f : 0.0f;
					}
					else if (tweak.type == ProceduralPropertyType.Enum)
					{
						value.x = sub.GetProceduralEnum(tweak.name);
						EnumCount++;
						scrollPosEnumList.Add(Vector2.zero);
					}
					current_tweak_ui_value.Add(tweak.name,value);
				}
				if(tweak.name != "$normalformat" && tweak.name != "$time" && !TweaksList.Contains(tweak.name))
				{
					bool alreadyThere = false;
					foreach (ProceduralPropertyDescription tweak2 in TweaksList)
						if (tweak2.name == tweak.name)
						{
							alreadyThere = true;
						}
					if (!alreadyThere)	
					{
						TweaksList.Add(tweak);
					}
				}
			}
		}
	}

	
	//! Here we draw all the tweaks GUI elements
	void DrawTweaks()
	{
		float currentPosY = 35;
				
		GUI.Box (new Rect (10,10,250, Screen.height - 200),"");
		TweakRect = new Rect (20,26,250, Screen.height - 233);
		scrollViewVector = GUI.BeginScrollView (TweakRect, scrollViewVector,new Rect (20,20,230, TweaksList.Count*48));	
		
		int EnumIndex = 0;
		
		foreach(ProceduralPropertyDescription tweak in TweaksList)
		{
			string tweakSpaces = tweak.name.Replace('_',' ');
			
			//! The Random Seed is a special case
			if (tweak.name == "$randomseed")
			{
				GUI.Label(new Rect(offset.x, offset.y+currentPosY, sizeLabel.x, sizeLabel.y),"Random Seed");

				if(GUI.Button(new Rect(offset.x+sizeLabel.x,offset.y+currentPosY-5,sizeSlider.x,25),"Generate"))
				{
					UnityEngine.Random.seed = (int)Time.time;
					float random_value = (float)UnityEngine.Random.Range(0,100000);
					current_tweak_ui_value[tweak.name] = new Vector4(random_value,0.0f,0.0f,0.0f);
					if (Body.HasProceduralProperty(tweak.name))
					{
						Body.SetProceduralFloat(tweak.name,random_value);
					}
					if (Head.HasProceduralProperty(tweak.name))
					{
						Head.SetProceduralFloat(tweak.name,random_value);
					}
				}

				GUI.Label(new Rect(offset.x+sizeLabel.x+sizeSlider.x+5, offset.y+currentPosY, sizeLabel.x, sizeLabel.y),current_tweak_ui_value[tweak.name].x.ToString());
				currentPosY = currentPosY + sizeSlider.y + spaceBetweenSliders;
			}
			else if (tweak.type == ProceduralPropertyType.Float)
			{
				GUI.Label(new Rect(offset.x, offset.y+currentPosY, sizeLabel.x, sizeLabel.y),tweakSpaces);
				float float_value = current_tweak_ui_value[tweak.name].x;
				float_value = GUI.HorizontalSlider(new Rect(offset.x+sizeLabel.x,offset.y+currentPosY-8,sizeSlider.x,sizeSlider.y),float_value,tweak.minimum,tweak.maximum);
				current_tweak_ui_value[tweak.name] = new Vector4(float_value,0.0f,0.0f,0.0f);
				if (Body.HasProceduralProperty(tweak.name))
				{
					Body.SetProceduralFloat(tweak.name,float_value);
				}
				if (Head.HasProceduralProperty(tweak.name))
				{
					Head.SetProceduralFloat(tweak.name,float_value);
				}
				GUI.Label(new Rect(offset.x+sizeLabel.x+sizeSlider.x+3, offset.y+currentPosY, sizeLabel.x, sizeLabel.y),Math.Round(current_tweak_ui_value[tweak.name].x,2).ToString());
				currentPosY = currentPosY + sizeSlider.y + spaceBetweenSliders;
			}
			else if (tweak.type == ProceduralPropertyType.Boolean)
			{
				GUI.Label(new Rect(offset.x, offset.y+currentPosY, sizeLabel.x, sizeLabel.y),tweakSpaces);
				bool bool_value = current_tweak_ui_value[tweak.name].x == 0.0f ? false : true;
				bool_value = GUI.Toggle(new Rect(offset.x+sizeLabel.x,offset.y+currentPosY,sizeSlider.x,sizeSlider.y),bool_value,"");
				current_tweak_ui_value[tweak.name] = new Vector4(bool_value == true ? 1.0f : 0.0f,0.0f,0.0f,0.0f);
				if (Body.HasProceduralProperty(tweak.name))
				{
					Body.SetProceduralBoolean(tweak.name,bool_value);
				}
				if (Head.HasProceduralProperty(tweak.name))
				{
					Head.SetProceduralBoolean(tweak.name,bool_value);
				}
				currentPosY = currentPosY + sizeSlider.y + spaceBetweenSliders;
			}
			else if (tweak.type == ProceduralPropertyType.Enum)
			{
				//! EnumIndex is used in case we have multiple Enum parameters to avoid conflicts between ScrollViews
				GUI.Label(new Rect(offset.x, offset.y+currentPosY, sizeLabel.x, sizeLabel.y),tweakSpaces);
				scrollPosEnumList[EnumIndex] = GUI.BeginScrollView (new Rect(offset.x+sizeLabel.x,offset.y+currentPosY,sizeSlider.x+20,80), scrollPosEnumList[EnumIndex],new Rect(offset.x+sizeLabel.x,offset.y+currentPosY-5,sizeSlider.x+20,25*tweak.enumOptions.Length-15));
				int enum_value = (int)current_tweak_ui_value[tweak.name].x;
				enum_value = GUI.SelectionGrid (new Rect(offset.x+sizeLabel.x,offset.y+currentPosY-5,sizeSlider.x,25*tweak.enumOptions.Length-20),enum_value,tweak.enumOptions, 1);
				current_tweak_ui_value[tweak.name] = new Vector4(enum_value,0.0f,0.0f,0.0f);
				GUI.EndScrollView();
				if (Body.HasProceduralProperty(tweak.name))
				{
					Body.SetProceduralEnum(tweak.name,enum_value);
				}
				if (Head.HasProceduralProperty(tweak.name))
				{
					Head.SetProceduralEnum(tweak.name,enum_value);
				}
				currentPosY = currentPosY + 80 + spaceBetweenSliders;
				EnumIndex++;
			}
			else if (tweak.type == ProceduralPropertyType.Color3 || tweak.type == ProceduralPropertyType.Color4)
			{
				GUI.Label(new Rect(offset.x, offset.y+currentPosY, sizeLabel.x, sizeLabel.y),tweakSpaces);
				colorPickers[tweak.name].drawUI(new Rect(offset.x+sizeLabel.x,offset.y+currentPosY-5, 100, 30));
				currentPosY = currentPosY + 50 + spaceBetweenSliders;
			}
		}
		GUI.color = new Color(GUI.color.r,GUI.color.g,GUI.color.b,1);
		//! Finally we update the textures
		Body.RebuildTextures();
		Head.RebuildTextures();
		
		GUI.EndScrollView();
	}
}
