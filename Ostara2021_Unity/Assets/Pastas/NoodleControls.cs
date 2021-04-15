// GENERATED AUTOMATICALLY FROM 'Assets/Pastas/NoodleControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @NoodleControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @NoodleControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""NoodleControls"",
    ""maps"": [
        {
            ""name"": ""Noodle"",
            ""id"": ""cce92585-2a19-4b33-af65-6592b1d2c393"",
            ""actions"": [
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""561d305f-7dd6-455b-b100-dcd20856d22d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveHead"",
                    ""type"": ""Value"",
                    ""id"": ""7f08745e-4b5a-4ea0-82ce-9a3d4a773051"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveTail"",
                    ""type"": ""Value"",
                    ""id"": ""2d3f3cb4-0c7f-41b1-be6f-75b8b8fff814"",
                    ""expectedControlType"": ""Stick"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RaiseHead"",
                    ""type"": ""Value"",
                    ""id"": ""7a9a5ba1-7c19-4267-8748-889322ff6c78"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RaiseTail"",
                    ""type"": ""Value"",
                    ""id"": ""4fdd5d78-da69-4134-903e-684fd866e762"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9901b864-e16f-4b23-83a6-ad7912c7ee20"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fab5f509-fee9-419f-942d-0f124cce8f61"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveHead"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""48a4efd6-1448-4aec-aef3-a7a8266432bb"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveTail"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1ac51709-4d42-4404-9c15-4e590228004f"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RaiseHead"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dc2e71a3-e24d-4681-97f7-2ee23c6dc057"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RaiseTail"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Noodle
        m_Noodle = asset.FindActionMap("Noodle", throwIfNotFound: true);
        m_Noodle_Jump = m_Noodle.FindAction("Jump", throwIfNotFound: true);
        m_Noodle_MoveHead = m_Noodle.FindAction("MoveHead", throwIfNotFound: true);
        m_Noodle_MoveTail = m_Noodle.FindAction("MoveTail", throwIfNotFound: true);
        m_Noodle_RaiseHead = m_Noodle.FindAction("RaiseHead", throwIfNotFound: true);
        m_Noodle_RaiseTail = m_Noodle.FindAction("RaiseTail", throwIfNotFound: true);
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

    // Noodle
    private readonly InputActionMap m_Noodle;
    private INoodleActions m_NoodleActionsCallbackInterface;
    private readonly InputAction m_Noodle_Jump;
    private readonly InputAction m_Noodle_MoveHead;
    private readonly InputAction m_Noodle_MoveTail;
    private readonly InputAction m_Noodle_RaiseHead;
    private readonly InputAction m_Noodle_RaiseTail;
    public struct NoodleActions
    {
        private @NoodleControls m_Wrapper;
        public NoodleActions(@NoodleControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Jump => m_Wrapper.m_Noodle_Jump;
        public InputAction @MoveHead => m_Wrapper.m_Noodle_MoveHead;
        public InputAction @MoveTail => m_Wrapper.m_Noodle_MoveTail;
        public InputAction @RaiseHead => m_Wrapper.m_Noodle_RaiseHead;
        public InputAction @RaiseTail => m_Wrapper.m_Noodle_RaiseTail;
        public InputActionMap Get() { return m_Wrapper.m_Noodle; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NoodleActions set) { return set.Get(); }
        public void SetCallbacks(INoodleActions instance)
        {
            if (m_Wrapper.m_NoodleActionsCallbackInterface != null)
            {
                @Jump.started -= m_Wrapper.m_NoodleActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_NoodleActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_NoodleActionsCallbackInterface.OnJump;
                @MoveHead.started -= m_Wrapper.m_NoodleActionsCallbackInterface.OnMoveHead;
                @MoveHead.performed -= m_Wrapper.m_NoodleActionsCallbackInterface.OnMoveHead;
                @MoveHead.canceled -= m_Wrapper.m_NoodleActionsCallbackInterface.OnMoveHead;
                @MoveTail.started -= m_Wrapper.m_NoodleActionsCallbackInterface.OnMoveTail;
                @MoveTail.performed -= m_Wrapper.m_NoodleActionsCallbackInterface.OnMoveTail;
                @MoveTail.canceled -= m_Wrapper.m_NoodleActionsCallbackInterface.OnMoveTail;
                @RaiseHead.started -= m_Wrapper.m_NoodleActionsCallbackInterface.OnRaiseHead;
                @RaiseHead.performed -= m_Wrapper.m_NoodleActionsCallbackInterface.OnRaiseHead;
                @RaiseHead.canceled -= m_Wrapper.m_NoodleActionsCallbackInterface.OnRaiseHead;
                @RaiseTail.started -= m_Wrapper.m_NoodleActionsCallbackInterface.OnRaiseTail;
                @RaiseTail.performed -= m_Wrapper.m_NoodleActionsCallbackInterface.OnRaiseTail;
                @RaiseTail.canceled -= m_Wrapper.m_NoodleActionsCallbackInterface.OnRaiseTail;
            }
            m_Wrapper.m_NoodleActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @MoveHead.started += instance.OnMoveHead;
                @MoveHead.performed += instance.OnMoveHead;
                @MoveHead.canceled += instance.OnMoveHead;
                @MoveTail.started += instance.OnMoveTail;
                @MoveTail.performed += instance.OnMoveTail;
                @MoveTail.canceled += instance.OnMoveTail;
                @RaiseHead.started += instance.OnRaiseHead;
                @RaiseHead.performed += instance.OnRaiseHead;
                @RaiseHead.canceled += instance.OnRaiseHead;
                @RaiseTail.started += instance.OnRaiseTail;
                @RaiseTail.performed += instance.OnRaiseTail;
                @RaiseTail.canceled += instance.OnRaiseTail;
            }
        }
    }
    public NoodleActions @Noodle => new NoodleActions(this);
    public interface INoodleActions
    {
        void OnJump(InputAction.CallbackContext context);
        void OnMoveHead(InputAction.CallbackContext context);
        void OnMoveTail(InputAction.CallbackContext context);
        void OnRaiseHead(InputAction.CallbackContext context);
        void OnRaiseTail(InputAction.CallbackContext context);
    }
}