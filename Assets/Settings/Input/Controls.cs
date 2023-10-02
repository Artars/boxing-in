//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.5.1
//     from Assets/Settings/Input/Controls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @Controls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""2f203ae0-6be7-40f3-ba7a-8eedef205ef6"",
            ""actions"": [
                {
                    ""name"": ""MoveX"",
                    ""type"": ""Value"",
                    ""id"": ""faee81aa-5ad1-4d99-9d71-74cc49508a95"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""MoveY"",
                    ""type"": ""Value"",
                    ""id"": ""fe4ebf9f-0a27-4ab9-abcb-c5b6532e0870"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Pick"",
                    ""type"": ""Button"",
                    ""id"": ""1bccc4ef-57f4-43a1-8a49-8714a4e33337"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""271fc284-28ac-4c9f-be95-faaa1329baf7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateClockwise"",
                    ""type"": ""Button"",
                    ""id"": ""66ffe818-b7e4-4f41-aa2b-f4f81b2a2a3f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""RotateAntiClockwise"",
                    ""type"": ""Button"",
                    ""id"": ""c8ab440d-ab3b-4bee-ba67-6b1ed0d4465f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Pack"",
                    ""type"": ""Button"",
                    ""id"": ""44a5d110-283d-447e-b5d4-e389d7b25279"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MoveUI"",
                    ""type"": ""Value"",
                    ""id"": ""1e20ef2e-33dd-45e5-aa20-c7bf4845ff66"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""Joystick"",
                    ""id"": ""70192d58-1aef-43cc-a124-99b16db56e8f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""522fc164-03ac-45a1-823a-94bc78ab2941"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""7a60c581-e0cc-4c9d-8103-42b195f1a997"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""d1cbe1dd-7b8e-431f-9d74-0296ad7e3d79"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""6c5fd29e-bc94-4c89-af56-0039abf3b879"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""9fec97d9-341d-4299-957d-ac68b10fc065"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyboardKeys"",
                    ""id"": ""fbf24da7-76eb-4f6a-a6fd-bd0895c49b14"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveX"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""63271465-b2a2-4e18-af3f-331db3f3ce29"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""ecd21845-7c31-43c5-9c46-f6814b505c2f"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Joystick"",
                    ""id"": ""0e961140-67d3-4d1d-86a8-02f0dbdc6236"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""ba0810d3-92aa-46d2-afb9-af92dc1b07b6"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0f3116fc-4b0d-4f64-b25f-f2c0236da767"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""c4c429e0-3711-47f8-b146-95d13a9cbe93"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""abea2592-b02d-486e-9b96-7e6c17fd9f0f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4247ccc2-e680-45d0-a8a6-5be3f0bdaf7c"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyboardKeys"",
                    ""id"": ""b04a060a-402e-4ec4-aafd-4c9032ae874a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveY"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""e940888e-6789-4394-b214-a451baaf47f6"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""732b0beb-8fdc-430e-bc25-9a2553d01ba1"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""MoveY"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bed89d33-b57f-42f8-b6bf-14718ea38196"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Pick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8ee1ea94-b244-44f0-bd9a-7109baa7b7a6"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Pick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9592d97-6730-4e61-b811-25a4396f69ea"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2b36c9b-d0a2-4f75-9483-9dddd6adea55"",
                    ""path"": ""<Keyboard>/backspace"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Player"",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""87631d72-17ae-47b4-b907-f7a5115674dc"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateClockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b4b9dce-7275-410a-97dd-b36a10237efb"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateClockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b632bd9-c0ad-4b1b-ab4f-4bc8dea942c3"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateAntiClockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e7ec8d3-4f1b-4ad9-8c97-fc42dbe270aa"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RotateAntiClockwise"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1f718bf0-6d23-49d4-9a55-9dc1b4fd4972"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79f06804-10b2-4aa1-8d25-92d20eeabf16"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""1f509450-013f-440e-8b4e-88a7092cd139"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7d47bc74-b64e-4788-a676-90112b6ea771"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""13240f3d-b46a-4185-a1c3-4fc876066cb8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6ceff9aa-bbb3-4ec7-9504-551f087bb207"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""ced41b53-668a-4a8d-913e-87abcf87e907"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""KeyboardArrows"",
                    ""id"": ""311fa5ce-f4c4-4edc-978c-37d90f165876"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""704832c2-65e0-407c-bd4f-d214c1f055cc"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""d8b54766-a0ce-4256-9f52-5a188a16dd6b"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""cf63b60b-4681-4239-b0a9-071fa964a613"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""bd50ab04-b395-4b73-9343-31ad804de8cc"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Gamepad"",
                    ""id"": ""aff8679c-d0b2-4bf6-b7f2-ad3ea89d1903"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e8eb545b-2e53-467b-983d-ff7aa7245d39"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""2f164063-3980-463e-aa09-4bd7ec65725e"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a37ddee9-ce47-4de6-9f8a-40ea84e32314"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""10c94d45-3987-4103-9ce5-926924e50ac8"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveUI"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Player"",
            ""bindingGroup"": ""Player"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_MoveX = m_Gameplay.FindAction("MoveX", throwIfNotFound: true);
        m_Gameplay_MoveY = m_Gameplay.FindAction("MoveY", throwIfNotFound: true);
        m_Gameplay_Pick = m_Gameplay.FindAction("Pick", throwIfNotFound: true);
        m_Gameplay_Cancel = m_Gameplay.FindAction("Cancel", throwIfNotFound: true);
        m_Gameplay_RotateClockwise = m_Gameplay.FindAction("RotateClockwise", throwIfNotFound: true);
        m_Gameplay_RotateAntiClockwise = m_Gameplay.FindAction("RotateAntiClockwise", throwIfNotFound: true);
        m_Gameplay_Pack = m_Gameplay.FindAction("Pack", throwIfNotFound: true);
        m_Gameplay_MoveUI = m_Gameplay.FindAction("MoveUI", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_Gameplay_MoveX;
    private readonly InputAction m_Gameplay_MoveY;
    private readonly InputAction m_Gameplay_Pick;
    private readonly InputAction m_Gameplay_Cancel;
    private readonly InputAction m_Gameplay_RotateClockwise;
    private readonly InputAction m_Gameplay_RotateAntiClockwise;
    private readonly InputAction m_Gameplay_Pack;
    private readonly InputAction m_Gameplay_MoveUI;
    public struct GameplayActions
    {
        private @Controls m_Wrapper;
        public GameplayActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MoveX => m_Wrapper.m_Gameplay_MoveX;
        public InputAction @MoveY => m_Wrapper.m_Gameplay_MoveY;
        public InputAction @Pick => m_Wrapper.m_Gameplay_Pick;
        public InputAction @Cancel => m_Wrapper.m_Gameplay_Cancel;
        public InputAction @RotateClockwise => m_Wrapper.m_Gameplay_RotateClockwise;
        public InputAction @RotateAntiClockwise => m_Wrapper.m_Gameplay_RotateAntiClockwise;
        public InputAction @Pack => m_Wrapper.m_Gameplay_Pack;
        public InputAction @MoveUI => m_Wrapper.m_Gameplay_MoveUI;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @MoveX.started += instance.OnMoveX;
            @MoveX.performed += instance.OnMoveX;
            @MoveX.canceled += instance.OnMoveX;
            @MoveY.started += instance.OnMoveY;
            @MoveY.performed += instance.OnMoveY;
            @MoveY.canceled += instance.OnMoveY;
            @Pick.started += instance.OnPick;
            @Pick.performed += instance.OnPick;
            @Pick.canceled += instance.OnPick;
            @Cancel.started += instance.OnCancel;
            @Cancel.performed += instance.OnCancel;
            @Cancel.canceled += instance.OnCancel;
            @RotateClockwise.started += instance.OnRotateClockwise;
            @RotateClockwise.performed += instance.OnRotateClockwise;
            @RotateClockwise.canceled += instance.OnRotateClockwise;
            @RotateAntiClockwise.started += instance.OnRotateAntiClockwise;
            @RotateAntiClockwise.performed += instance.OnRotateAntiClockwise;
            @RotateAntiClockwise.canceled += instance.OnRotateAntiClockwise;
            @Pack.started += instance.OnPack;
            @Pack.performed += instance.OnPack;
            @Pack.canceled += instance.OnPack;
            @MoveUI.started += instance.OnMoveUI;
            @MoveUI.performed += instance.OnMoveUI;
            @MoveUI.canceled += instance.OnMoveUI;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @MoveX.started -= instance.OnMoveX;
            @MoveX.performed -= instance.OnMoveX;
            @MoveX.canceled -= instance.OnMoveX;
            @MoveY.started -= instance.OnMoveY;
            @MoveY.performed -= instance.OnMoveY;
            @MoveY.canceled -= instance.OnMoveY;
            @Pick.started -= instance.OnPick;
            @Pick.performed -= instance.OnPick;
            @Pick.canceled -= instance.OnPick;
            @Cancel.started -= instance.OnCancel;
            @Cancel.performed -= instance.OnCancel;
            @Cancel.canceled -= instance.OnCancel;
            @RotateClockwise.started -= instance.OnRotateClockwise;
            @RotateClockwise.performed -= instance.OnRotateClockwise;
            @RotateClockwise.canceled -= instance.OnRotateClockwise;
            @RotateAntiClockwise.started -= instance.OnRotateAntiClockwise;
            @RotateAntiClockwise.performed -= instance.OnRotateAntiClockwise;
            @RotateAntiClockwise.canceled -= instance.OnRotateAntiClockwise;
            @Pack.started -= instance.OnPack;
            @Pack.performed -= instance.OnPack;
            @Pack.canceled -= instance.OnPack;
            @MoveUI.started -= instance.OnMoveUI;
            @MoveUI.performed -= instance.OnMoveUI;
            @MoveUI.canceled -= instance.OnMoveUI;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    private int m_PlayerSchemeIndex = -1;
    public InputControlScheme PlayerScheme
    {
        get
        {
            if (m_PlayerSchemeIndex == -1) m_PlayerSchemeIndex = asset.FindControlSchemeIndex("Player");
            return asset.controlSchemes[m_PlayerSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnMoveX(InputAction.CallbackContext context);
        void OnMoveY(InputAction.CallbackContext context);
        void OnPick(InputAction.CallbackContext context);
        void OnCancel(InputAction.CallbackContext context);
        void OnRotateClockwise(InputAction.CallbackContext context);
        void OnRotateAntiClockwise(InputAction.CallbackContext context);
        void OnPack(InputAction.CallbackContext context);
        void OnMoveUI(InputAction.CallbackContext context);
    }
}
