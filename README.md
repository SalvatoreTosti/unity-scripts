# unity-scripts
A storage place for commonly used Unity scripts

## Editor

### ClickEditorWindow.cs

_Overview:_

GUIWindow template for an editor window which responds to clicks in the scene.

_Usage:_

Place script in Assets/Editor then navigate to Window > Click Tracking Window from the menubar.

### ObjectArrayGenerator.cs

_Overview:_

GUIWindow which allows user to quickly generate arrays objects.
The editor supports 2D and 3D array generation.
It also supports parenting to existing objects, or it can generate an empty object which will become the parent for all generated objects.

_Usage:_

Place script in Assets/Editor then navigate to Window > Click Tracking Window from the menubar.

___

## Scripts

### EditorGridSnap.cs

_Overview:_

Snaps object to the nearest x, y and z coordinates.

_Usage:_

Attach the script to any object.
Object movement in the editor will then be snapped to the nearest whole x,y,z coordinate.

### XYEditorGridSnap.cs

_Overview:_

Snaps object to the nearest x and y coordinates.

_Usage:_

Attach the script to any object.
Object movement in the editor will then be snapped to the nearest whole x, y coordinate, remaining at it's current z coordinate.
This is helpful when snapping in a 2D environment.

### EditorAutoParent.cs

_Overview:_

Automatically makes object a child of selected parent.

_Usage:_

Attach the script to any object.
Select parent object in the editor menu.
