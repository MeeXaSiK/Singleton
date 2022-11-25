# NightSingleton
Perfect Singleton for Unity by [Night Train Code](https://www.youtube.com/c/NightTrainCode/)

# How to use

1. Install `Singleton` into your Unity project
2. Optionally, you can inherit a class from `Singleton<TClass>`

```csharp

public class Player : Singleton<Player>
{
    [SerializeField] private UnitViewModel model;
    
    public UnitViewModel ViewModel => model;
}

public class Demo : MonoBehaviour
{
    private void Start()
    {
        var playerModel = Player.Instance.ViewModel;
    }
}

```

or

```csharp

public class Player : MonoBehaviour
{
    [SerializeField] private UnitViewModel model;
    
    public UnitViewModel ViewModel => model;
}

public class Demo : MonoBehaviour
{
    private void Start()
    {
        var playerModel = Singleton<Player>.Instance.ViewModel;
    }
}

```
