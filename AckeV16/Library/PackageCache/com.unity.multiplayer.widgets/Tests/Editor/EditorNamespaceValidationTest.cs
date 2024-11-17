using System;
using UnityEditor;
using UnityEngine;

internal class EditorNamespaceValidationTest : Editor
{
    // This "test" is to prevent accidental namespace ambiguity (caused by Riders semi-smartness in creating a namespace from folder hierarchy).
    // If some namespace in our package starts with "Editor.****" this takes precedence over the Editor type from the UnityEditor namespace.
    // This "test" should create a compile time error in the PR already if that case happens.
}