using UnityEditor;
using UnityEngine;
using ArchNet.Library.Color;
using ArchNet.Library.Image;
using System.Collections.Generic;

namespace ArchNet.Library.Enum.Editor
{
    /// <summary>
    /// [LIBRARY] - [ARCH NET] - [ENUM] Library Enum Editor
    /// author : LOUIS PAKEL
    /// </summary>
    [CustomEditor(typeof(EnumLibrary))]
    public class EnumLibraryEditor : UnityEditor.Editor
    {
        #region Private Field

        int _listCount;

        SerializedProperty _imageModels = null;
        SerializedProperty _colorsModels = null;
        SerializedProperty _enums = null;

        EnumLibrary _manager = null;

        GUIStyle _warningInfos = null;

        private void OnEnable()
        {
            _warningInfos = new GUIStyle();
            _warningInfos.normal.textColor = UnityEngine.Color.red;
            _warningInfos.fontStyle = FontStyle.Bold;

            _manager = target as EnumLibrary;
            _manager.LoadAllEnums();
        }

        private void OnDisable()
        {
            _manager = null;
            _warningInfos = null;
        }


        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.LabelField("ENUM LIBRARY");
            EditorGUILayout.LabelField("This library link a library ( ColorLibrary, ImageLibrary) with a enum on string format");

            _imageModels = serializedObject.FindProperty("_imageModels");
            _colorsModels = serializedObject.FindProperty("_colorsModels");
            _enums = serializedObject.FindProperty("_enums");

            EditorGUILayout.Space(10);

            EditorGUILayout.BeginHorizontal();

            // Manage Color MODEL Button
            ColorButton();

            // Manage Image MODEL Button
            ImageButton();

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(10);

            // Check if 
            if (IsConditionsOK() == true)
            {
                // Display colors models
                DisplayColorModels();

                EditorGUILayout.Space(10);

                EditorGUILayout.LabelField("____________________________________________________________________________________________________________________________________________________________________________________________________");

                EditorGUILayout.Space(10);

                // Display images models
                DisplayImageModels();
            }

            // Apply modifications
            serializedObject.ApplyModifiedProperties();
        }

        /// <summary>
        /// Description : Color Model Button Management
        /// </summary>
        private void ColorButton()
        {
            // BUTTON COLOR MODEL
            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("Add a COLOR LIBRARY"))
            {
                _manager.AddColorModel();
            }

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(10);
        }

        /// <summary>
        /// Description : Image Model Button Management
        /// </summary>
        private void ImageButton()
        {
            // BUTTON IMAGE LIBRARY
            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Add a IMAGE LIBRARY"))
            {
                _manager.AddImageModel();
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space(10);
        }


        /// <summary>
        /// Description : Displau Color Models
        /// </summary>
        private void DisplayColorModels()
        {
            // Color MODEL
            EditorGUILayout.LabelField("COLOR MODEL", EditorStyles.boldLabel);

            _listCount = _colorsModels.arraySize;
            for (int i = 0; i < _listCount; i++)
            {
                SerializedProperty lColorModel = _colorsModels.GetArrayElementAtIndex(i);
                SerializedProperty lColorLibrary = lColorModel.FindPropertyRelative("_colorLibrary");

                SerializedProperty lEnumIndex = lColorModel.FindPropertyRelative("_index");

                lColorModel.isExpanded = EditorGUILayout.Foldout(lColorModel.isExpanded, new GUIContent("Color Model " + i));
                if (lColorModel.isExpanded)
                {
                    EditorGUILayout.BeginHorizontal();
                    lColorLibrary.objectReferenceValue = (ColorLibrary)EditorGUILayout.ObjectField(lColorLibrary.objectReferenceValue, typeof(ColorLibrary), false);
                    EditorGUILayout.EndHorizontal();
                    if (lColorLibrary.objectReferenceValue != null)
                    {
                        ColorLibrary lColor = (ColorLibrary)lColorLibrary.objectReferenceValue;

                        if (lColor.GetKeyType() == 1)
                        {
                            EditorGUILayout.BeginHorizontal();
                            EditorGUILayout.LabelField("Enum Path");

                            string[] lEnumList = _manager.GetAllEnums().ToArray();

                            lEnumIndex.intValue = EditorGUILayout.Popup(lEnumIndex.intValue, lEnumList);

                            string lEnumName = _manager.GetEnumName(lEnumIndex.intValue);

                            _manager.GetColorModels()[i].SetEnum(lEnumName);

                            EditorGUILayout.EndHorizontal();

                            if (false == lColor.IsEnumEqual(_manager.GetEnumType(lEnumName)))
                            {
                                EditorGUILayout.BeginHorizontal();
                                EditorGUILayout.LabelField("THE ENUM IS NOT THE RIGHT ONE, Are you sure to use this one ?", _warningInfos);
                                EditorGUILayout.EndHorizontal();
                            }
                        }
                    }
                    EditorGUILayout.BeginHorizontal();

                    if (GUILayout.Button("Delete"))
                    {
                        if (EditorUtility.DisplayDialog("Warning", "Are you sure to delete this enum?", "Yes", "No"))
                        {
                            lColorModel.isExpanded = false;
                            _colorsModels.DeleteArrayElementAtIndex(i);
                            break;
                        }
                    }

                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.Space(5);
                }
            }
        }

        /// <summary>
        /// Description : Displau Image Models
        /// </summary>
        private void DisplayImageModels()
        {
            // Image MODEL
            EditorGUILayout.LabelField("IMAGE MODEL", EditorStyles.boldLabel);

            _listCount = _imageModels.arraySize;
            for (int i = 0; i < _listCount; i++)
            {
                SerializedProperty lImageModel = _imageModels.GetArrayElementAtIndex(i);
                SerializedProperty lImageLibrary = lImageModel.FindPropertyRelative("_imageLibrary");

                SerializedProperty lEnumIndex = lImageModel.FindPropertyRelative("_index");

                lImageModel.isExpanded = EditorGUILayout.Foldout(lImageModel.isExpanded, new GUIContent("Image Model " + i));
                if (lImageModel.isExpanded)
                {
                    EditorGUILayout.BeginHorizontal();
                    lImageLibrary.objectReferenceValue = (ImageLibrary)EditorGUILayout.ObjectField(lImageLibrary.objectReferenceValue, typeof(ImageLibrary), false);
                    EditorGUILayout.EndHorizontal();

                    if (lImageLibrary.objectReferenceValue != null)
                    {
                        ImageLibrary lImage = (ImageLibrary)lImageLibrary.objectReferenceValue;

                        if (lImage.GetActualKeyType() == 1)
                        {
                            EditorGUILayout.BeginHorizontal();

                            EditorGUILayout.LabelField("Enum Path");

                            string[] lEnumList = _manager.GetAllEnums().ToArray();

                            lEnumIndex.intValue = EditorGUILayout.Popup(lEnumIndex.intValue, lEnumList);

                            string lEnumName = _manager.GetEnumName(lEnumIndex.intValue);

                            _manager.GetImageModels()[i].SetEnum(lEnumName);

                            EditorGUILayout.EndHorizontal();

                            if (false == lImage.IsEnumEqual(_manager.GetEnumType(lEnumName)))
                            {
                                EditorGUILayout.BeginHorizontal();
                                EditorGUILayout.LabelField("THE ENUM IS NOT THE RIGHT ONE, Are you sure to use this one ?", _warningInfos);
                                EditorGUILayout.EndHorizontal();
                            }
                        }

                    }
                    EditorGUILayout.BeginHorizontal();

                    if (GUILayout.Button("Delete"))
                    {
                        if (EditorUtility.DisplayDialog("Warning", "Are you sure to delete this enum?", "Yes", "No"))
                        {
                            lImageModel.isExpanded = false;
                            _imageModels.DeleteArrayElementAtIndex(i);
                            break;
                        }
                    }

                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.Space(5);
                }
            }
        }

        /// <summary>
        /// Description : check if every condition are respected
        /// </summary>
        /// <returns></returns>
        private bool IsConditionsOK()
        {
            if (_colorsModels == null && _imageModels == null)
            {
                return false;
            }
            if (_colorsModels.arraySize == 0 && _imageModels.arraySize == 0)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
