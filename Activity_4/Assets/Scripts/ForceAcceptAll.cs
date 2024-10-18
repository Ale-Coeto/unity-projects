using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ForceAcceptAll : CertificateHandler
{
    // Script para validar el certificado (saltar el proceso de verificación)
    protected override bool ValidateCertificate(byte[] certificateD)
    {
        return true;
    }


}