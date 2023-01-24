using Morpeh;
using UnityEngine;
using Unity.IL2CPP.CompilerServices;
using UniRx;

[Il2CppSetOption(Option.NullChecks, false)]
[Il2CppSetOption(Option.ArrayBoundsChecks, false)]
[Il2CppSetOption(Option.DivideByZeroChecks, false)]
[CreateAssetMenu(menuName = "ECS/Systems/" + nameof(InputReadMouseSystem))]
public sealed class InputReadMouseSystem : UpdateSystem 
{
    private CompositeDisposable disposables;

    private bool canCreate;

    public override void OnAwake() 
    {
        disposables = new CompositeDisposable();
        canCreate = true;
    }

    public override void OnUpdate(float deltaTime) 
    {
        if (Input.GetMouseButton(0) && canCreate && !GameSettings.isPause)
        {
            canCreate = false;

            Observable.Timer(System.TimeSpan.FromSeconds(.05f))
                .Subscribe(_ =>
                {
                    ref var c = ref World.CreateEntity().AddComponent<InputMouseClickComponent>();
                    c.position = Input.mousePosition;
                    canCreate = true;
                }).AddTo(disposables);
        }
    }
}