# 🚄 Singleton
[![License](https://img.shields.io/github/license/MeeXaSiK/Singleton?color=318CE7&style=flat-square)](LICENSE.md) [![Version](https://img.shields.io/github/package-json/v/MeeXaSiK/Singleton?color=318CE7&style=flat-square)](package.json) [![Unity](https://img.shields.io/badge/Unity-2020.3+-2296F3.svg?color=318CE7&style=flat-square)](https://unity.com/)

Singleton for Unity by [Night Train Code](https://www.youtube.com/c/NightTrainCode/)

* 🚀 Performance
* 🔒 Thread safety
* 💫 Persistence supported
* 🛡️ Protection against misuse

# ▶ Installation

Supports installation as a Unity module via a git link in the **PackageManager**
```
https://github.com/MeeXaSiK/Singleton.git
```
or direct editing of `Packages/manifest.json`:
```
"com.nighttraincode.singleton": "https://github.com/MeeXaSiK/Singleton.git",
```
## As source
You can also clone the code into your Unity project.

# 🔸 How to use

Inherit a class from `Singleton<T>` where `T : Singleton<T>`
```csharp

public class Player : Singleton<Player>
{

}
```
Get instance using `Instance` property.
```csharp
_player = Singleton<Player>.Instance;
```
```csharp
_player = Player.Instance;
```

If you need `Awake` method, use `OnAwake` instead.

```csharp

public class Player : Singleton<Player>
{
    protected override void OnAwake()
    {
        // Your code here.
    }
}
```

# 🔸 Persistence

If you want to make the singleton persistent, then enable the `Dont Destroy On Load` option in the inspector of class, that inherited from `Singleton<T>`.
