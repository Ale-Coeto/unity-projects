using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using static SelectCover;

// Seleccionar portada
public class SelectCover : MonoBehaviour
{
    Texture2D image;
    Sprite newSprite;
    public Image newImage;

    public Books bookNumber = Books.book1;

    // Libros (en unity)
    public enum Books
    {
        book1, book2, book3, book4, book5, book6, book7
    }

    // Fetch de datos de todos los libros para asignar portadas
    IEnumerator Start()
    {
        string JSONurl = "https://localhost:7249/api/Book/GetBooks";

        UnityWebRequest web = UnityWebRequest.Get(JSONurl);
        web.useHttpContinue = true;
        var cert = new ForceAcceptAll();
        web.certificateHandler = cert;
        cert?.Dispose();


        yield return web.SendWebRequest();

        Debug.Log("URL 2");

        if (web.result != UnityWebRequest.Result.Success)
        {
            UnityEngine.Debug.Log("Error en API:" + web.error);
        }
        else
        {
            List<Book> bookList = new List<Book>();
            bookList = JsonConvert.DeserializeObject<List<Book>>(web.downloadHandler.text);

            string cover = bookList[(int)bookNumber].cover;
            Debug.Log(cover);
            StartCoroutine(DownloadImage(cover));
        }
    }

    // Obtener imágenes del url y asignarlos a la imagen de portada
    IEnumerator DownloadImage(string MediaURL)
    {
        
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(MediaURL);
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log("IMG " + request.error);
        }
        else
        {
            image = ((DownloadHandlerTexture)request.downloadHandler).texture;
            newSprite = Sprite.Create(image, new Rect(0.0f, 0.0f, image.width, image.height), new Vector2(0.5f, 0.5f), 100.0f);
            newImage.sprite = newSprite;
        }
    }
}
