# NightSingleton
Perfect Singleton for Unity by [Night Train Code](https://www.youtube.com/c/NightTrainCode/)

# How to use

1. Install `Singleton` into your Unity project
2. Inherit any class from `Singleton<TClass>`

```csharp

public class Player : Singleton<Player>
{
    public UnitViewModel model;
}

public class Demo : MonoBehaviour
{
    private void Start()
    {
        var playerModel = Player.Instance.model;
    }
}

```
or

```csharp

public class Player : Singleton<Player>
{
    public UnitViewModel model;
}

public class Demo : MonoBehaviour
{
    private void Start()
    {
        var playerModelCanBeNull = Player.GetCanBeNull().model;
        var playerModelNotNull = Player.GetNotNull().model;
    }
}

```

or

```csharp

public class Player : MonoBehaviour
{
    public UnitViewModel model;
}

public class Demo : MonoBehaviour
{
    private void Start()
    {
        var player = Singleton<Player>.Instance;
    }
}

```
