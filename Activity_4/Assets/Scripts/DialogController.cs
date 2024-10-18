using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using System.Linq;

// Texto de página
public class DialogController : MonoBehaviour
{
    public Text pageText;
    private int pageNo;

    public Text dialogueText;
    string[] Sentences = { " ", " ", " " };
    private int Index = 0;
    public float dialogeSpeed = 2.1f;
    public float delayToWrite = 2.1f;
    private int book;


    // Obtener id del libro seleccionado
    void Start()
    {
        book = PlayerPrefs.GetInt("book_no");
        StartCoroutine(GetData());
        StartCoroutine(WriteSentence());
        //Debug.Log("BK  " + book);
    }

    // Obtener datos de la api (datos del libro seleccionado)
    IEnumerator GetData()
    {
        string JSONurl = "https://localhost:7249/api/Page/" + book;
        UnityWebRequest web = UnityWebRequest.Get(JSONurl);
        web.useHttpContinue = true;
        var cert = new ForceAcceptAll();
        web.certificateHandler = cert;
        cert?.Dispose();


        yield return web.SendWebRequest();

        if (web.result != UnityWebRequest.Result.Success)
        {
            UnityEngine.Debug.Log("Error en API:" + web.error);
        }
        else
        {
            List<Page> pageList = new List<Page>();
            pageList = JsonConvert.DeserializeObject<List<Page>>(web.downloadHandler.text);
            Debug.Log("BK" + book);

            if (pageList.Count > 0)
            {
                Sentences = Enumerable.Repeat<string>("", pageList.Count).ToArray<string>();

                for (var i = 0; i < pageList.Count; i++)
                {
                   Sentences[i] = pageList[i].page;
                }

                //Debug.Log("s " + Sentences[0]);
            }
        }

    }

    // Escribir las oraciones (animacion)
    IEnumerator WriteSentence()
    {
        pageNo = Index + 1;
        pageText.text = pageNo.ToString();

        yield return new WaitForSeconds(delayToWrite);

        foreach (char Character in Sentences[Index].ToCharArray())
        {
            dialogueText.text += Character;
            Debug.Log(dialogueText.text);
            yield return new WaitForSeconds(dialogeSpeed);
        }
    }

    // Cambiar de página 
    public void Next()
    {
        StopAllCoroutines();
        if (Index < Sentences.Length - 1)
        Index++;
        NextSentence();
    }

    // Regresar página
    public void Past()
    {
        StopAllCoroutines();
        if (Index > 0)
            Index--;
        NextSentence();
    }

    // Escribir siguiente oración (si existe)
    public void NextSentence()
    {
        if (Index <= Sentences.Length - 1 || Index < 0)
        {
            dialogueText.text = Sentences[Index];
            dialogueText.text = " ";
            StartCoroutine(WriteSentence());
        }
    }
}
