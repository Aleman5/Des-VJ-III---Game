﻿using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class DataManager
{
    [System.Serializable]
    public struct Data
    {
        /// <summary>
        /// Scene saved
        /// </summary>
        public SceneEnum actualScene;
        public int moneyCount;
        public string waveName;
        public int[] playerUpgrades;

        /// <summary>
        /// Count of bodies saved
        /// </summary>
        public int enemyBodies;

        /// <summary>
        /// Is a game already created?
        /// </summary>
        public bool saveCreated;
    }

	public static DataManager current;

    public Data data;

	public DataManager()
    {
        data.playerUpgrades = new int[(int)Buyable.COUNT];
    }

    public void SetPreparations()
    {
        data.actualScene = (SceneEnum)System.Enum.Parse(typeof(SceneEnum), SceneManager.GetActiveScene().name);

        if (data.actualScene != SceneEnum.StoryboardN1 && data.actualScene != SceneEnum.StoryboardN2)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            data.moneyCount = player.GetComponent<MoneyHolder>().ActualMoney;
            data.waveName = GameObject.FindGameObjectWithTag("WaveSpawner").GetComponent<WaveSpawner>().GetActualWaveName();
            data.enemyBodies = BodiesHolder.Instance.GetBodies();

            PlayerMovement3D pMovScript = player.GetComponent<PlayerMovement3D>();

            for (int i = 0; i < (int)Buyable.COUNT; i++)
                data.playerUpgrades[i] = pMovScript.GetUpgradeValue(i);

            //SpriteRenderer[] srs = BodiesHolder.Instance.GetBodies();

            /*if (srs != null)
                for (int i = 0; i < data.enemyBodies.Length; i++)
                {
                    if (i < srs.Length)
                        data.enemyBodies[i] = srs[i];
                    else
                        data.enemyBodies[i] = null;
                }*/
        }
        else
        {
            data.waveName = "wave 1";
        }

        data.saveCreated = true;


    }
}