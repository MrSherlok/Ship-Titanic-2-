using UnityEngine;
using System.Collections.Generic;

public class RandomBackgroudGenerator : MonoBehaviour {
    public List<string> Backgrounds = new List<string> ();  //Список имен префабов
        
    private int currentIndex = -1; 
    private int lastIndex = 0;
    private List<int> indexes = new List<int>();

    void Start()
    {
        Shuffle();

        for (int c = 0; c < 25; c++) GenerateNext ();
    }

    void Shuffle()
    {
        if (Backgrounds.Count <= 1) return;

        indexes.Clear ();
        for (int i = 0; i < Backgrounds.Count; i++) {
            indexes.Add(i);
        }

        indexes.Sort((a, b) => Random.Range(0, 100) > 50 ? -1 : 1);

        if (lastIndex == indexes[0])
        {
            int v = indexes[0];
            indexes[0] = indexes[indexes.Count - 1];
            indexes[indexes.Count - 1] = v;
        }
    }

    public void GenerateNext()
    {
        string name = "";
        // Тут проверка на то, сколько у нас элементов в списке
        if (Backgrounds.Count == 0) return;
        if (Backgrounds.Count == 1)
        {
            name = Backgrounds[0];
        }
        else
        {
            currentIndex++;

            //Если прошли полностью все бэки, пересортировуем.
            if (currentIndex == Backgrounds.Count)
            {
                currentIndex = 0;
                Shuffle();
            }

            name = Backgrounds[indexes[currentIndex]];
        }

        //Тут ваш код который отвечает за генерацию исходя из полученого имени
        var groud = Object.Instantiate(Resources.Load(name)) as GameObject;
    }
}
