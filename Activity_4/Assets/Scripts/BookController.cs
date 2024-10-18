using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;
using UnityEngine.Networking;
using Newtonsoft.Json;
using static SelectCover;

// Controlador 
public class BookController : MonoBehaviour
{
    static public BookController Instance;
    public SelectCover selectCover;
    public SelectBook selectBook;

    public Text nameText;
    public Text authorText;

    public int bookSelection;

    // Instancia
    private void Awake()
    {
        Instance = this;
        Instance.setReferences();
        DontDestroyOnLoad(this.gameObject);
    }

    // Obtener las referencias a los libros
    void setReferences()
    {
        if (selectCover == null)
        {
            selectCover = FindAnyObjectByType<SelectCover>();
        }
        if (selectBook == null)
        {
            selectBook = FindAnyObjectByType<SelectBook>();
        }
    }

    // Indicar el libro seleccionado
    public void Select(int _selection)
    {
        bookSelection = _selection;
        StartCoroutine(GetData());
    }

    // Fetch de los datos de la api (lista de libros con sus datos)
    IEnumerator GetData()
    {
        string JSONurl = "https://localhost:7249/api/Book/GetBooks";
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
            List<Book> bookList = new List<Book>();
            bookList = JsonConvert.DeserializeObject<List<Book>>(web.downloadHandler.text);

            LoadBookInfo(bookSelection, bookList);
            PlayerPrefs.SetInt("book_no", bookSelection);
            Debug.Log("SEle " + bookSelection);
        }
    }

    // Indicar el libro seleccionado y actualizar los títulos
    public void LoadBookInfo(int idBook, List<Book> bookList)
    {
        Debug.Log(idBook);
        string book = bookList[idBook - 1].name;
        PlayerPrefs.SetString("book_name", book);
        nameText.text = book;
        string author = bookList[idBook - 1].author;
        PlayerPrefs.SetString("author", author);
        authorText.text = author;
        Debug.Log(author);
    }

}
