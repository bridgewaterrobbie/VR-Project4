﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

namespace VRAVE
{
    public class HUDController : MonoBehaviour
    {


        private Transform centerTextField;
        private Transform leftTextField;
        private Transform rightTextField;
        private Transform topTextField;
        private Transform bottomTextField;

        private Transform centerImageField;
        private Transform leftImageField;
        private Transform rightImageField;

        private TextMesh centerText;
        private TextMesh leftText;
        private TextMesh rightText;
        private TextMesh topText;
        private TextMesh bottomText;

        private bool isHUDImageEnabled = true;
        private bool isHUDTextEnabled = true;

        private TextMesh newMesh;

        public HUDModel model;

        public HUDModel[] models;
        public float[] durations;

        // Use this for initialization
        void Awake()
        {

            /* Example use case for your code (should be in the scenario class or somewhere)
             * 
             * MyScenarioClass {
             * 	HUDModel myHud = new MyHUDModel(); //<- a HUD model initialized w/ your HUD strings, images
             * 									   // this model should extend HUDModel_Upright (for upright angles)
             *									   // it must extend HUDModel
             * 
             * 	HUDController.model = myHud;
             * 
             * 	// to change hud models
             * 
             * HUDController.model = newModel;
             *
             * //or do
             *
             * myHud.centerText = "new center text"; //to change text
             * myHud.centerBackingMaterial = myImageMaterial; //to change images
             * myHud.isCenterImageEnabled = true; //to enable/disable image or text fields
             * 
             *
             * */

            model = new HUDVRAVE_Default(); //This is the layout that we decided we liked best. The other ones still exist
                                            //just in case we want to use them. 
            transform.eulerAngles = model.HUDRotation;

            centerImageField = transform.Find("HUDImage_Center");
            leftImageField = transform.Find("HUDImage_Left");
            rightImageField = transform.Find("HUDImage_Right");

            centerTextField = transform.Find("HUDText_Center");
            leftTextField = transform.Find("HUDText_Left");
            rightTextField = transform.Find("HUDText_Right");
            topTextField = transform.Find("HUDText_Top");
            bottomTextField = transform.Find("HUDText_Bottom");

            centerText = centerTextField.GetComponent<TextMesh>();
            leftText = leftTextField.GetComponent<TextMesh>();
            rightText = rightTextField.GetComponent<TextMesh>();
            topText = topTextField.GetComponent<TextMesh>();
            bottomText = bottomTextField.GetComponent<TextMesh>();

        }
			
		public void EngageAIMode() 
		{
			model.leftText = VRAVEStrings.Autonomous_Mode;
		}

		public void EngageManualMode() 
		{
			model.leftText = VRAVEStrings.Manual_Mode;
		}

		public void FlashImage(Material img, float timeOn, float timeOff, float imgScale, int numberOfTimesToFlash, HUDAsyncController contrllr)
		{
			models [1] = model;
			durations [0] = timeOn;
			durations [1] = timeOff;
			models [0] = model.Clone ();
			models [0].leftBackingMaterial = img;
			models [0].isLeftImageEnabled = true;
			models [0].leftImagePosition = new Vector3 (1.98f, 0.19f, -0.39f);
			models [0].leftImageScale = new Vector3 (imgScale * 0.1280507f, 0, imgScale * 0.1280507f);
			contrllr.DoHUDUpdates (numberOfTimesToFlash, timeOn + timeOff);
		}

		public void Clear()
		{
			model.centerText = "";
			model.rightText = "";
			model.topText = "";
			model.bottomText = "";
			model.isLeftImageEnabled = false;
		}

        // Update is called once per frame
        void Update()
        {

            updateCenterImageField();
            updateLeftImageField();
            updateRightImageField();

            updateCenterTextField();
            updateLeftTextField();
            updateRightTextField();
            updateBottomTextField();
            updateTopTextField();

            /*	bool g = CrossPlatformInputManager.GetButtonDown ("HUDImageEnable");
                if (g) {
                    isHUDImageEnabled = !isHUDImageEnabled;
                }*/

            bool h = CrossPlatformInputManager.GetButtonDown("HUDTextEnable");
            if (h)
            {
                isHUDTextEnabled = !isHUDTextEnabled;
            }

        }

        void updateCenterImageField()
        {
			centerImageField.transform.localPosition = model.centerImagePosition;
			centerImageField.transform.localScale = model.centerImageScale;
			centerImageField.GetComponent<MeshRenderer> ().enabled = model.isCenterImageEnabled && isHUDImageEnabled;
			centerImageField.GetComponent<MeshRenderer> ().material = model.centerBackingMaterial;
        }

        void updateLeftImageField()
        {
			leftImageField.transform.localPosition = model.leftImagePosition;
			leftImageField.transform.localScale = model.leftImageScale;
			leftImageField.GetComponent<MeshRenderer> ().enabled = model.isLeftImageEnabled && isHUDImageEnabled;
			leftImageField.GetComponent<MeshRenderer> ().material = model.leftBackingMaterial;
        }

        void updateRightImageField()
        {
			rightImageField.transform.localPosition = model.rightImagePosition;
			rightImageField.transform.localScale = model.rightImageScale;
			rightImageField.GetComponent<MeshRenderer> ().enabled = model.isRightImageEnabled && isHUDImageEnabled;
			rightImageField.GetComponent<MeshRenderer> ().material = model.rightBackingMaterial;
        }

        void updateCenterTextField()
        {
			centerText.text = model.centerText;
			centerTextField.transform.localPosition = model.centerTextPosition;
			centerText.characterSize = model.centerCharSize;
			centerText.fontSize = model.centerFontSize;
			centerTextField.GetComponent<MeshRenderer> ().enabled = model.isCenterTextEnabled && isHUDTextEnabled;
        }

        void updateLeftTextField()
        {
			leftText.text = model.leftText;
			leftTextField.transform.localPosition = model.leftTextPosition;
			leftText.characterSize = model.leftCharSize;
			leftText.fontSize = model.leftFontSize;
			leftTextField.GetComponent<MeshRenderer> ().enabled = model.isLeftTextEnabled && isHUDTextEnabled;
        }

        void updateRightTextField()
        {
			rightText.text = model.rightText;
			rightTextField.transform.localPosition = model.rightTextPosition;
			rightText.characterSize = model.rightCharSize;
			rightText.fontSize = model.rightFontSize;
			rightTextField.GetComponent<MeshRenderer> ().enabled = model.isRightTextEnabled && isHUDTextEnabled;
        }

        void updateBottomTextField()
        {
			bottomText.text = model.bottomText;
			bottomTextField.transform.localPosition = model.bottomTextPosition;
			bottomText.characterSize = model.bottomCharSize;
			bottomText.fontSize = model.bottomFontSize;
			bottomTextField.GetComponent<MeshRenderer> ().enabled = model.isBottomTextEnabled && isHUDTextEnabled;
        }

        void updateTopTextField()
        {
			topText.text = model.topText;
			topTextField.transform.localPosition = model.topTextPosition;
			topText.characterSize = model.topCharSize;
			topText.fontSize = model.topFontSize;
			topTextField.GetComponent<MeshRenderer> ().enabled = model.isTopTextEnabled && isHUDTextEnabled;
        }

    }
}