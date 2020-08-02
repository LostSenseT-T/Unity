using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] treeElemPrefabs;

    public List<GameObject> branches;
    public GameObject cuttedAnim;
    public GameObject cuttedAnimLeft;

    private bool createTrunk = true;
    void Start()
    {
        // разница в высоте между чанками 1.74

        /*
        GameObject branchEmpty = Instantiate(treeElemPrefabs[0]); // обычное дерево
        branchEmpty.transform.parent = gameObject.transform;
        branchEmpty.transform.localPosition = new Vector3(-0.277f, -2.8f, -1f);
   
        GameObject branchLeft = Instantiate(treeElemPrefabs[1]); // левая палка
        branchLeft.transform.parent = gameObject.transform;
        branchLeft.transform.localPosition = new Vector3(-0.277f, -1.06f, -1f);
       
        GameObject branchRight = Instantiate(treeElemPrefabs[2]); // правая палка
        branchRight.transform.parent = gameObject.transform;
        branchRight.transform.localPosition = new Vector3(-0.277f, 0.68f, -1f);
        */

        for (int i = 0; i < 10; i += 2) // бесконечный цикл, всегда будет 10 веток впереди
        {
            GameObject
            branchEmpty = Instantiate(treeElemPrefabs[0]); // обычное дерево
            branchEmpty.transform.parent = gameObject.transform;
            branchEmpty.transform.localPosition = new Vector3(-0.191f, 0 + (1.74f * i), -1f); // следующая позиция ветки

            branches.Add(branchEmpty);

            GameObject branchLeftOrRight = Instantiate(getRandomBranch()); // рандомная ветка
            branchLeftOrRight.transform.parent = gameObject.transform;
            branchLeftOrRight.transform.localPosition = new Vector3(-0.191f, 0 + (1.74f * (i + 1)), -1f); // следующая позиция ветки

            branches.Add(branchLeftOrRight);
        }      
    }
    private GameObject getRandomBranch() // рандомизатор чанка ветки
    {
        int random = Random.Range(0, 150);

        if (random <= 50)
        {
            return treeElemPrefabs[1]; // возвращает левую ветку 
        }
        else if (random <= 100)
        {
            return treeElemPrefabs[2]; // возвращает правую ветку 
        }

        return treeElemPrefabs[0]; // всегда выводить один пустой эллемент дерева для играбельности 
    }
    public void cutFirstTrunk(string diractionTrunk)
    {
        Destroy(branches[0]); // уничтожает первый ствол в списке
        if (diractionTrunk == "RIGHT")
        {
            Instantiate(cuttedAnim, new Vector3(0, 0.8f, 0), Quaternion.identity);
        }
        else
        {
            Instantiate(cuttedAnimLeft, new Vector3(0, 0.8f, 0), Quaternion.identity);
        }
        //branches[0].GetComponent<Trunk>().onAnimateDestroy(diractionTrunk); // уничтожение с анимацией
        branches.RemoveAt(0); // удаляет пустой эллемент из списка

        int i = 0;
        for (i = 0; i < branches.Count; i++)
        {
            branches[i].transform.localPosition = new Vector3(branches[i].transform.position.x, i * 1.74f, branches[i].transform.position.z);
        }

        GameObject trunk = Instantiate(createTrunk ? treeElemPrefabs[0] : getRandomBranch()); // создаем новый кусок дерева
        trunk.transform.parent = gameObject.transform;
        trunk.transform.position = new Vector3(-0.191f, 0 + (1.74f * (i+1)), -1f); // переставляем его позицию складывая каждый новый ствол внутрь родителяя

        branches.Add(trunk); // заносим ствол в список

        createTrunk = !createTrunk; // меняем условие на противоположное
    }
    public string getDirectionFirstTrunk()
    {
        return branches[0].tag.ToString();
    }
    public void reset()
    {
        for (int i = 0; i < branches.Count; i++) // удаляем все сущесвующие обьекты
        {
            Destroy(branches[i]);
        }
        branches.RemoveRange(0, branches.Count); // удадяем все эллементы в списке
      
        /*
        // НЕ ВАРИАНТ РЕШЕНИЯ ПРОБЛЕМЫ
        GameObject branchEmpty = Instantiate(treeElemPrefabs[0]); // обычное дерево
        branchEmpty.transform.parent = gameObject.transform;
        branchEmpty.transform.localPosition = new Vector3(-0.277f, 14.7f, -1f); // следующая позиция ветки
        */

        Start();
    }
}
