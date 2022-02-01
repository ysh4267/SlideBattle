using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    //2차원 원 범위 안의 영역에서 랜덤 생성
    [SerializeField] Vector3 centerPosition;
    [SerializeField] float radius;
    [SerializeField] float yOffset;
    [SerializeField] int feverTimeCoinCount;
    [SerializeField] float feverTimeCoinSpawnTimeInterval;
    [SerializeField] float defaultCoinSpawnTimeInterval;

    List<GameObject> coinList;

    private void Start()
    {
        coinList = new List<GameObject>();
    }

    public void DestroyAndClearCoinList()
    {
        foreach (GameObject coin in coinList)
        {
            Destroy(coin);
        }
       
        coinList.Clear();
    }

    public void SpawnCoin()
    {
        GameObject newCoin = Instantiate(Resources.Load<GameObject>("Prefabs/Coin"));
        newCoin.transform.position = GetRandomPosition();
        coinList.Add(newCoin);
    }
    public void TriggerFeverTime(float probability)
    {
        float randomNumber= Random.Range(0,100);
        Debug.Log(randomNumber);
        Debug.Log(probability);
        if (randomNumber < probability)
        {
            Debug.Log("fever!");
            StartCoroutine("SpawnFeverCoin");
        }
    }
    public void TriggerDefaultCoinSpawn()
    {
        Debug.Log("1213");
        StartCoroutine("SpawnCoinDefault");
    }
    public void StopEveryCoinSpawn()
    {
        StopAllCoroutines();
    }
    IEnumerator SpawnCoinDefault()
    {

        while(Observers.GetInstance().panelHandler.GetCurrentPanelStatus() == ENUM_PANEL_STATUS.IN_GAME){
            SpawnCoin();
            yield return new WaitForSeconds(defaultCoinSpawnTimeInterval);
        }
    }

    IEnumerator SpawnFeverCoin()
    {
        int count = 0;
        while (count <= feverTimeCoinCount) {
            SpawnCoin();
            count++;
            yield return new WaitForSeconds(feverTimeCoinSpawnTimeInterval);
        }
    }
    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = new Vector3();

        float xpos = Random.Range(-1*radius,radius);
        float zpos = Random.Range(-1*Mathf.Sqrt((radius * radius) - (xpos * xpos)), Mathf.Sqrt((radius*radius)-(xpos*xpos)));

        randomPosition = new Vector3(xpos+centerPosition.x,yOffset+centerPosition.y,zpos+centerPosition.z);

        return randomPosition;
    }
}
