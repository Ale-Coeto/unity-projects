using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BookInfo : MonoBehaviour
{

    private string title;
    public Text titleText;

    private string author;
    public Text authorText;

    private int book;

    // Obtener libro seleciconado y datos
    void Start()
    {
        title = PlayerPrefs.GetString("book_name");
        author = PlayerPrefs.GetString("author");
        book = PlayerPrefs.GetInt("book_no");

        titleText.text = title;
        authorText.text = author;
        
    }


}
