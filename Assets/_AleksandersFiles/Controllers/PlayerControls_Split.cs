// GENERATED AUTOMATICALLY FROM 'Assets/_AleksandersFiles/Controllers/PlayerControls_Split.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls_Split : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerControls_Split()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls_Split"",
    ""maps"": [
        {
            ""name"": ""Split_Gameplay"",
            ""id"": ""5430ea01-384c-4cfb-9ab2-1c01ef76a7dc"",
            ""actions"": [
                {
                    ""name"": ""LeftCharMovement"",
                    ""type"": ""Button"",
                    ""id"": ""9f8e1191-afcb-446b-b86b-9949a05702a1"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightCharMovement"",
                    ""type"": ""Button"",
                    ""id"": ""2cb8fbb8-b04b-49ce-925e-e658403858a2"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c31a8b77-06b7-42b4-b15d-09461f230ff7"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""LeftCharMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""aabd587c-fe32-4e0b-ae5c-dd9b7527c8a1"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RightCharMovement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Split_Gameplay
        m_Split_Gameplay = asset.GetActionMap("Split_Gameplay");
        m_Split_Gameplay_LeftCharMovement = m_Split_Gameplay.GetAction("LeftCharMovement");
        m_Split_Gameplay_RightCharMovement = m_Split_Gameplay.GetAction("RightCharMovement");
    }

    ~PlayerControls_Split()
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

    // Split_Gameplay
    private readonly InputActionMap m_Split_Gameplay;
    private ISplit_GameplayActions m_Split_GameplayActionsCallbackInterface;
    private readonly InputAction m_Split_Gameplay_LeftCharMovement;
    private readonly InputAction m_Split_Gameplay_RightCharMovement;
    public struct Split_GameplayActions
    {
        private PlayerControls_Split m_Wrapper;
        public Split_GameplayActions(PlayerControls_Split wrapper) { m_Wrapper = wrapper; }
        public InputAction @LeftCharMovement => m_Wrapper.m_Split_Gameplay_LeftCharMovement;
        public InputAction @RightCharMovement => m_Wrapper.m_Split_Gameplay_RightCharMovement;
        public InputActionMap Get() { return m_Wrapper.m_Split_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Split_GameplayActions set) { return set.Get(); }
        public void SetCallbacks(ISplit_GameplayActions instance)
        {
            if (m_Wrapper.m_Split_GameplayActionsCallbackInterface != null)
            {
                LeftCharMovement.started -= m_Wrapper.m_Split_GameplayActionsCallbackInterface.OnLeftCharMovement;
                LeftCharMovement.performed -= m_Wrapper.m_Split_GameplayActionsCallbackInterface.OnLeftCharMovement;
                LeftCharMovement.canceled -= m_Wrapper.m_Split_GameplayActionsCallbackInterface.OnLeftCharMovement;
                RightCharMovement.started -= m_Wrapper.m_Split_GameplayActionsCallbackInterface.OnRightCharMovement;
                RightCharMovement.performed -= m_Wrapper.m_Split_GameplayActionsCallbackInterface.OnRightCharMovement;
                RightCharMovement.canceled -= m_Wrapper.m_Split_GameplayActionsCallbackInterface.OnRightCharMovement;
            }
            m_Wrapper.m_Split_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                LeftCharMovement.started += instance.OnLeftCharMovement;
                LeftCharMovement.performed += instance.OnLeftCharMovement;
                LeftCharMovement.canceled += instance.OnLeftCharMovement;
                RightCharMovement.started += instance.OnRightCharMovement;
                RightCharMovement.performed += instance.OnRightCharMovement;
                RightCharMovement.canceled += instance.OnRightCharMovement;
            }
        }
    }
    public Split_GameplayActions @Split_Gameplay => new Split_GameplayActions(this);
    public interface ISplit_GameplayActions
    {
        void OnLeftCharMovement(InputAction.CallbackContext context);
        void OnRightCharMovement(InputAction.CallbackContext context);
    }
}
