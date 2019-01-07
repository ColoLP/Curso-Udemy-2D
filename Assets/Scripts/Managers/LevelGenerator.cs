using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    //El primer nivel lo vamos a mantener fijo. 


    public List<LevelBlock> allTheLevelBlocks = new List<LevelBlock>();
    public Transform levelStartPoint;
    public List<LevelBlock> currentBlocks = new List<LevelBlock>();

    #region Singleton
    public static LevelGenerator sharedInstance;

    private void Awake()
    {
        sharedInstance = this;    
    }
    #endregion

    void Start()
    {
        GenerateInitialBlock();
    }
    
    public void AddLevelBlock()
    {
        int randIndex = Random.Range(0, allTheLevelBlocks.Count);

        LevelBlock currentBlock = (LevelBlock)Instantiate(allTheLevelBlocks[randIndex]); //Usa el cast, asegura que es tipo LevelBlock
        currentBlock.transform.SetParent(this.transform,false);      //Nose por que pero, lo quiere poneren debajo del generador de nivel en la jerarquia. Por ahi para que sea mas facil de manejar. 

        Vector3 spawnPosition = Vector3.zero;

        if(currentBlocks.Count  == 0)
        {
            spawnPosition = levelStartPoint.position; // Esto sirve para poner el primero, y unicamente el primero.
        }
        else
        {
            spawnPosition = currentBlocks[currentBlocks.Count - 1].exitPoint.position; // En la clase level block tengo solo los 2 transforms.
        }


        Vector3 correction = new Vector3(spawnPosition.x - currentBlock.startPoint.position.x, spawnPosition.y - currentBlock.startPoint.position.y, 0f);

        Debug.Log(correction);
        currentBlock.transform.position = correction; // Le asigna la posicion al spawn point calculado. 
        currentBlocks.Add(currentBlock); //Voy agregando los bloques instanciados al pull de bloques.



    }

    //Elimina el bloque mas viejo. 
    public void RemoveOldestLevelBlock()
    {
        LevelBlock oldestBlock = currentBlocks[0];
        currentBlocks.Remove(oldestBlock);
        Destroy(oldestBlock); //Siempre sera el mas viejo, por que es una FiLo
    }

    //Sirve para el Game Over
    public void RemoveAllLevelBlock()
    {
        while (currentBlocks.Count > 0)
        {
            RemoveOldestLevelBlock();
        }
    }
    //Se utiliza para el inicio de Juego.
    public void GenerateInitialBlock()
    {
        //Puedo generar la cantidad de Bloques que quiera inicialmente. 
        for (int i = 0; i < 3; i++) 
        {
            AddLevelBlock();
        }
    }
    
}
