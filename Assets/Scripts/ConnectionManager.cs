using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

using Unity.Netcode;
using Unity.Netcode.Transports.UTP;

public class ConnectionManager : MonoBehaviour
{
    public Button StartHost;    
    public Button StartClient;

    public UnityTransport ipInfo;

    public string IP
    {
        get => ipInfo.ConnectionData.Address;
        set => ipInfo.ConnectionData.Address = value;
    }

    public string Port
    {
        get => ipInfo.ConnectionData.Port.ToString();
        set => ipInfo.ConnectionData.Port = ushort.Parse(value);

    }

    private void Awake()
    {
        StartClient?.onClick.AddListener(()=> {
            NetworkManager.Singleton.StartClient();

        });

        StartHost?.onClick.AddListener(() => {
            NetworkManager.Singleton.StartHost();
        });
    }

}
