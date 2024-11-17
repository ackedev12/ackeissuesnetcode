using System;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using Unity.Multiplayer.Widgets;
using Unity.Multiplayer.Widgets.Editor;
using UnityEditor.SceneManagement;
using Object = UnityEngine.Object;

// ReSharper disable CoVariantArrayConversion

class WidgetCreationTest 
{
	struct TestData
	{
		public Action Method;
	}
	
	[Test]
	public void CreateCreateSessionWidget() 
	{
		WidgetCreation.CreateCreateSessionWidget();
		
		var sessionObject = Object.FindObjectsByType<CreateSession>(FindObjectsSortMode.None);
		AssertWidgetCreation(sessionObject, out var canvas);
		AssertWidgetParentIsCanvas(sessionObject[0].transform, canvas.transform);
	}
	
	[Test]
	public void CreateQuickJoinSessionWidget() 
	{
		WidgetCreation.CreateQuickJoinSessionWidget();
		
		var sessionObject = Object.FindObjectsByType<QuickJoinSession>(FindObjectsSortMode.None);
		AssertWidgetCreation(sessionObject, out var canvas);
		AssertWidgetParentIsCanvas(sessionObject[0].transform, canvas.transform);
	}
	
	[Test]
	public void CreateSessionListWidget() 
	{
		WidgetCreation.CreateSessionListWidget();
		
		var sessionObject = Object.FindObjectsByType<SessionList>(FindObjectsSortMode.None);
		AssertWidgetCreation(sessionObject, out var canvas);
		AssertWidgetParentIsCanvas(sessionObject[0].transform, canvas.transform);
	}
	
	[Test]
	public void CreateShowSessionCodeWidget() 
	{
		WidgetCreation.CreateShowSessionCodeWidget();
		
		var sessionObject = Object.FindObjectsByType<ShowJoinCode>(FindObjectsSortMode.None);
		AssertWidgetCreation(sessionObject, out var canvas);
		
		AssertWidgetParentIsCanvas(sessionObject[0].transform, canvas.transform);
	}
	
	[Test]
	public void CreateJoinSessionWithCodeWidget() 
	{
		WidgetCreation.CreateJoinSessionByCodeWidget();
		
		var sessionObject = Object.FindObjectsByType<JoinSessionByCode>(FindObjectsSortMode.None);
		AssertWidgetCreation(sessionObject, out var canvas);
		AssertWidgetParentIsCanvas(sessionObject[0].transform, canvas.transform);
	}

	static void AssertWidgetCreation(MonoBehaviour[] sessionObject, out Canvas canvas)
	{
		Assert.AreEqual(sessionObject.Length, 1, "There should be only one Widget in the scene");

		var canvasArray = Object.FindObjectsByType<Canvas>(FindObjectsSortMode.None);
		Assert.AreEqual(canvasArray.Length, 1, "There should be only one canvas in the scene");
		canvas = canvasArray[0];
	}

	static void AssertWidgetParentIsCanvas(Transform widget, Transform canvasTransform)
	{
		Assert.AreEqual(widget.parent, canvasTransform, "Widget root should be a direct child of the canvas");
	}
	
	[UnityTearDown]
	void TearDown()
	{
		EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);
	}
}
