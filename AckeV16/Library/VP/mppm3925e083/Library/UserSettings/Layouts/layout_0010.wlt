%YAML 1.1
%TAG !u! tag:unity3d.com,2011:
--- !u!114 &1
MonoBehaviour:
  m_ObjectHideFlags: 52
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: 0}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 12004, guid: 0000000000000000e000000000000000, type: 0}
  m_Name: 
  m_EditorClassIdentifier: 
  m_PixelRect:
    serializedVersion: 2
    x: 91
    y: 228
    width: 1229
    height: 804
  m_ShowMode: 2
  m_Title: Player 3
  m_RootView: {fileID: 2}
  m_MinSize: {x: 875, y: 300}
  m_MaxSize: {x: 10000, y: 10000}
  m_Maximized: 0
--- !u!114 &2
MonoBehaviour:
  m_ObjectHideFlags: 52
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: 0}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 12008, guid: 0000000000000000e000000000000000, type: 0}
  m_Name: 
  m_EditorClassIdentifier: 
  m_Children:
  - {fileID: 3}
  - {fileID: 6}
  m_Position:
    serializedVersion: 2
    x: 0
    y: 0
    width: 1229
    height: 804
  m_MinSize: {x: 875, y: 300}
  m_MaxSize: {x: 10000, y: 10000}
  m_UseTopView: 1
  m_TopViewHeight: 30
  m_UseBottomView: 0
  m_BottomViewHeight: 0
--- !u!114 &3
MonoBehaviour:
  m_ObjectHideFlags: 52
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: 0}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 12047, guid: 0000000000000000e000000000000000, type: 0}
  m_Name: TopView
  m_EditorClassIdentifier: 
  m_Children: []
  m_Position:
    serializedVersion: 2
    x: 0
    y: 0
    width: 1229
    height: 30
  m_MinSize: {x: 50, y: 50}
  m_MaxSize: {x: 4000, y: 4000}
  m_ActualView: {fileID: 7}
--- !u!114 &4
MonoBehaviour:
  m_ObjectHideFlags: 52
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: 0}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 12006, guid: 0000000000000000e000000000000000, type: 0}
  m_Name: ConsoleWindow
  m_EditorClassIdentifier: 
  m_Children: []
  m_Position:
    serializedVersion: 2
    x: 0
    y: 318
    width: 1229
    height: 456
  m_MinSize: {x: 50, y: 74}
  m_MaxSize: {x: 4000, y: 4024}
  m_ActualView: {fileID: 8}
  m_Panes:
  - {fileID: 8}
  m_Selected: 0
  m_LastSelected: 0
--- !u!114 &5
MonoBehaviour:
  m_ObjectHideFlags: 52
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: 0}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 12006, guid: 0000000000000000e000000000000000, type: 0}
  m_Name: GameView
  m_EditorClassIdentifier: 
  m_Children: []
  m_Position:
    serializedVersion: 2
    x: 0
    y: 0
    width: 1229
    height: 318
  m_MinSize: {x: 50, y: 76}
  m_MaxSize: {x: 4000, y: 4026}
  m_ActualView: {fileID: 9}
  m_Panes:
  - {fileID: 9}
  m_Selected: 0
  m_LastSelected: 0
--- !u!114 &6
MonoBehaviour:
  m_ObjectHideFlags: 52
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: 0}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 12010, guid: 0000000000000000e000000000000000, type: 0}
  m_Name: 
  m_EditorClassIdentifier: 
  m_Children:
  - {fileID: 5}
  - {fileID: 4}
  m_Position:
    serializedVersion: 2
    x: 0
    y: 30
    width: 1229
    height: 774
  m_MinSize: {x: 50, y: 150}
  m_MaxSize: {x: 4000, y: 8050}
  vertical: 1
  controlID: 131
  draggingID: 0
--- !u!114 &7
MonoBehaviour:
  m_ObjectHideFlags: 52
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: 0}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 11500000, guid: 3ed2472a8526a42d1af55f185c2802b8, type: 3}
  m_Name: 
  m_EditorClassIdentifier: 
  m_MinSize: {x: 50, y: 50}
  m_MaxSize: {x: 4000, y: 4000}
  m_TitleContent:
    m_Text: Unity.Multiplayer.Playmode.Workflow.Editor.TopView
    m_Image: {fileID: 0}
    m_Tooltip: 
    m_TextWithWhitespace: "Unity.Multiplayer.Playmode.Workflow.Editor.TopView\u200B"
  m_Pos:
    serializedVersion: 2
    x: 91
    y: 228
    width: 1229
    height: 30
  m_SerializedDataModeController:
    m_DataMode: 0
    m_PreferredDataMode: 0
    m_SupportedDataModes: 
    isAutomatic: 1
  m_ViewDataDictionary: {fileID: 0}
  m_OverlayCanvas:
    m_LastAppliedPresetName: Default
    m_SaveData: []
    m_ContainerData: []
    m_OverlaysVisible: 1
--- !u!114 &8
MonoBehaviour:
  m_ObjectHideFlags: 52
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: 0}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 12003, guid: 0000000000000000e000000000000000, type: 0}
  m_Name: 
  m_EditorClassIdentifier: 
  m_MinSize: {x: 50, y: 50}
  m_MaxSize: {x: 4000, y: 4000}
  m_TitleContent:
    m_Text: Console
    m_Image: {fileID: -4327648978806127646, guid: 0000000000000000d000000000000000, type: 0}
    m_Tooltip: 
    m_TextWithWhitespace: "Console\u200B"
  m_Pos:
    serializedVersion: 2
    x: 91
    y: 576
    width: 1229
    height: 432
  m_SerializedDataModeController:
    m_DataMode: 0
    m_PreferredDataMode: 0
    m_SupportedDataModes: 
    isAutomatic: 1
  m_ViewDataDictionary: {fileID: 0}
  m_OverlayCanvas:
    m_LastAppliedPresetName: Default
    m_SaveData: []
    m_ContainerData: []
    m_OverlaysVisible: 1
--- !u!114 &9
MonoBehaviour:
  m_ObjectHideFlags: 52
  m_CorrespondingSourceObject: {fileID: 0}
  m_PrefabInstance: {fileID: 0}
  m_PrefabAsset: {fileID: 0}
  m_GameObject: {fileID: 0}
  m_Enabled: 1
  m_EditorHideFlags: 0
  m_Script: {fileID: 12015, guid: 0000000000000000e000000000000000, type: 0}
  m_Name: 
  m_EditorClassIdentifier: 
  m_MinSize: {x: 50, y: 50}
  m_MaxSize: {x: 4000, y: 4000}
  m_TitleContent:
    m_Text: Game
    m_Image: {fileID: -6423792434712278376, guid: 0000000000000000d000000000000000, type: 0}
    m_Tooltip: 
    m_TextWithWhitespace: "Game\u200B"
  m_Pos:
    serializedVersion: 2
    x: 91
    y: 258
    width: 1229
    height: 292
  m_SerializedDataModeController:
    m_DataMode: 0
    m_PreferredDataMode: 0
    m_SupportedDataModes: 
    isAutomatic: 1
  m_ViewDataDictionary: {fileID: 0}
  m_OverlayCanvas:
    m_LastAppliedPresetName: Default
    m_SaveData: []
    m_ContainerData: []
    m_OverlaysVisible: 1
  m_SerializedViewNames: []
  m_SerializedViewValues: []
  m_PlayModeViewName: GameView
  m_ShowGizmos: 0
  m_TargetDisplay: 0
  m_ClearColor: {r: 0, g: 0, b: 0, a: 0}
  m_TargetSize: {x: 1920, y: 1080}
  m_TextureFilterMode: 0
  m_TextureHideFlags: 61
  m_RenderIMGUI: 1
  m_EnterPlayModeBehavior: 0
  m_UseMipMap: 0
  m_VSyncEnabled: 0
  m_Gizmos: 0
  m_Stats: 0
  m_SelectedSizes: 03000000000000000000000000000000000000000000000000000000000000000000000000000000
  m_ZoomArea:
    m_HRangeLocked: 0
    m_VRangeLocked: 0
    hZoomLockedByDefault: 0
    vZoomLockedByDefault: 0
    m_HBaseRangeMin: -960
    m_HBaseRangeMax: 960
    m_VBaseRangeMin: -540
    m_VBaseRangeMax: 540
    m_HAllowExceedBaseRangeMin: 1
    m_HAllowExceedBaseRangeMax: 1
    m_VAllowExceedBaseRangeMin: 1
    m_VAllowExceedBaseRangeMax: 1
    m_ScaleWithWindow: 0
    m_HSlider: 0
    m_VSlider: 0
    m_IgnoreScrollWheelUntilClicked: 0
    m_EnableMouseInput: 1
    m_EnableSliderZoomHorizontal: 0
    m_EnableSliderZoomVertical: 0
    m_UniformScale: 1
    m_UpDirection: 1
    m_DrawArea:
      serializedVersion: 2
      x: 0
      y: 21
      width: 1229
      height: 271
    m_Scale: {x: 0.25092593, y: 0.25092593}
    m_Translation: {x: 614.5, y: 135.5}
    m_MarginLeft: 0
    m_MarginRight: 0
    m_MarginTop: 0
    m_MarginBottom: 0
    m_LastShownAreaInsideMargins:
      serializedVersion: 2
      x: -2448.93
      y: -540
      width: 4897.86
      height: 1080
    m_MinimalGUI: 1
  m_defaultScale: 0.25092593
  m_LastWindowPixelSize: {x: 1229, y: 292}
  m_ClearInEditMode: 1
  m_NoCameraWarning: 1
  m_LowResolutionForAspectRatios: 01000000000000000000
  m_XRRenderMode: 0
  m_RenderTexture: {fileID: 0}
