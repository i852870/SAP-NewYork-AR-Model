// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using HoloToolkit.Unity.Buttons;
using HoloToolkit.UX.Dialog;
using System.Collections;
using UnityEngine;

namespace HoloToolkit.Examples.UX
{
    /// <summary>
    /// Demonstrates how to launch Dialog UI with different number of buttons
    /// </summary>
    public class DialogExampleLaunchButton : MonoBehaviour
    {
        [SerializeField]
        private Dialog dialogPrefab;

        [SerializeField]
        private bool isDialogLaunched;

        [SerializeField]
        private GameObject resultText;
        /// <summary>
        /// Used to report the dialogResult. OK, Cancel etc.
        /// The button that was clicked to respond to the Dialog.
        /// </summary>
        public GameObject ResultText
        {
            get
            {
                return resultText;
            }

            set
            {
                resultText = value;
            }
        }

        [SerializeField]
        [Range(0,5)]
        private int numButtons = 1;

        private TextMesh resultTextMesh;
        private Button button;

        /// <summary>
        /// This function is called to set the settings for the dialog and then open it.
        /// </summary>
        /// <param name="buttons">Enum describing the number of buttons that will be created on the Dialog</param>
        /// <param name="title">This string will appear at the top of the Dialog</param>
        /// <param name="message">This string will appear in the body of the Dialog</param>
        /// <returns>IEnumerator used for Coroutine funtions in Unity</returns>
        protected IEnumerator LaunchDialog(DialogButtonType buttons, string title, string message)
        {
            isDialogLaunched = true;

            //Open Dialog by sending in prefab
            Dialog dialog = Dialog.Open(dialogPrefab.gameObject, buttons, title, message);

            if(dialog != null)
            {
                //listen for OnClosed Event
                dialog.OnClosed += OnClosed;
            }

            // Wait for dialog to close
            while (dialog.State < DialogState.InputReceived)
            {
                yield return null;
            }

            //only let one dialog be created at a time
            isDialogLaunched = false;

            yield break;
        }

        private void OnEnable()
        {
            resultTextMesh = ResultText.GetComponent<TextMesh>();
            button = GetComponent<Button>();
            if(button != null)
            {
                button.OnButtonClicked += OnButtonClicked;
            }
        }

        private void OnButtonClicked(GameObject obj)
        {
            if (isDialogLaunched == false)
            {
                if (numButtons == 1)
                {
                  //   Launch Dialog with single button
                    StartCoroutine(LaunchDialog(DialogButtonType.OK, "Freedom Tower ", "Height: 1792ft to the tip \nTotal Floors: 104 "));
                }
                else if (numButtons == 2)
                {
                    // Launch Dialog with two buttons
                    StartCoroutine(LaunchDialog(DialogButtonType.OK , "Brooklyn Bridge ", " Length: 5989ft \n Built in 1883"));
                }
                else if (numButtons == 3)
                {
                    // 
                    StartCoroutine(LaunchDialog(DialogButtonType.OK, "The Statue of Liberty ", "Height: 305ft to the tip \nBuilt in: 1886 "));
                }
                else if (numButtons == 4)
                {
                    // 
                    StartCoroutine(LaunchDialog(DialogButtonType.OK, "Empire State Building ", "Height: 1454ft to the tip \nBuilt in: 1931 "));
                }
                else if (numButtons == 5)
                {
                    // 
                    StartCoroutine(LaunchDialog(DialogButtonType.OK, "Central Park ", "Area: 1.317mi^2 "));
                }
            }
        }

        /// <summary>
        /// Event Handler that fires when Dialog is closed- when a button on the Dialog is clicked.
        /// </summary>
        /// <param name="result">Returns a description of the result, which button was clicked</param>
        protected void OnClosed(DialogResult result)
        {
            // Get the result text from the Dialog
            resultTextMesh.text = result.Result.ToString();
        }
    }
}
