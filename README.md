# com.kolodi.scriptable-goodies
Unity Scriptable Goodies

This package provides useful tools and ready to use systems based on scriptable objects. 
The main focus is the Events System which enables you to biuld a robust event driven architecture.

As for now, there is only one type of universal `AssetEvent`, an asset that you create in your project folder. 
You can raise it in many different ways with and without parameters from UnityEvents in inspector or from code.
Then you can subscribe to the event by using universal `EventsListener` or specific derived listeners or by creating `ListenerElement` on the fly in your code.

You can take avantage of `EventAssetArgument` which contains optional callbacks for situations where you might need them.

You can also chain events. By default, event argument propagates thruout the chained events, 
but you can override argument data in specific chained event otr create and use custom data converters for event argument.

Being yet under development, the package is already used in production in different froms. And it will be shaped it out into a stable release version soon.

The package has the following dependancies:
Unity Reorderable List: https://github.com/cfoulston/Unity-Reorderable-List
