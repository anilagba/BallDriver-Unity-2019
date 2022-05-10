using System.Collections;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    [SerializeField] GameObject obstackle;
    [SerializeField] GameObject star;
    [SerializeField] GameObject coin;
    [SerializeField] GameObject pointBooster;
    [SerializeField] GameObject makeBigger;
    [SerializeField] GameObject makeSmaller;
    [SerializeField] GameObject increaseBouncy;
    [SerializeField] GameObject decreaseBouncy;
    [SerializeField] GameObject[] spawnPointsCollectables;
    [SerializeField] GameObject[] spawnPointsObstackles;
    private int random;
    private void Start()
    {
        StartCoroutine(CreateObject());
    }

    private IEnumerator CreateObject()
    {
        while (true)
        {
            random = Random.Range(0, 201);
            CreateObstackle();

            if (random < 90)
            {

            }
            else if (random >= 130 && random < 150)
            {
                CreateIncBouncy();
            }
            else if (random >= 150 && random < 170)
            {
                CreateMakeBigger();
            }
            else if (random >= 170 && random < 190)
            {
                CreateStar();
            }
            else if (random >= 190)
            {
                CreatePointBooster();
            }
            else
            {
                CreateCoin();
            }
            yield return new WaitForSeconds(1.0f);
        }
    }

    #region CreateObstackle
    private void CreateObstackle()
    {
        int random = Random.Range(0, spawnPointsObstackles.Length);
        GameObject o = Instantiate(obstackle, spawnPointsObstackles[random].transform.position,
            Quaternion.Euler(obstackle.transform.rotation.x, obstackle.transform.rotation.y, Random.Range(0, 90)));

        o.transform.position = new Vector3(o.transform.position.x, o.transform.position.y, 110);

        Destroy(o, 10);
    }
    #endregion

    #region CreateDecBouncy
    private void CreateDecBouncy()
    {
        random = Random.Range(0, spawnPointsCollectables.Length);
        GameObject x = Instantiate(decreaseBouncy, spawnPointsCollectables[random].transform.position, Quaternion.identity);
        x.transform.position = new Vector3(x.transform.position.x, x.transform.position.y, 110);
        Destroy(x, 5);
    }
    #endregion

    #region CreateIncBouncy
    private void CreateIncBouncy()
    {
        random = Random.Range(0, spawnPointsCollectables.Length);
        GameObject x = Instantiate(increaseBouncy, spawnPointsCollectables[random].transform.position, Quaternion.identity);
        x.transform.position = new Vector3(x.transform.position.x, x.transform.position.y, 110);
        Destroy(x, 5);
    }
    #endregion

    #region CreatePointBooster
    private void CreatePointBooster()
    {
        random = Random.Range(0, spawnPointsCollectables.Length);
        GameObject x = Instantiate(pointBooster, spawnPointsCollectables[random].transform.position, Quaternion.identity);
        x.transform.position = new Vector3(x.transform.position.x, x.transform.position.y, 110);
        Destroy(x, 5);
    }
    #endregion

    #region CreateStar
    private void CreateStar()
    {
        random = Random.Range(0, spawnPointsCollectables.Length);
        GameObject x = Instantiate(star, spawnPointsCollectables[random].transform.position, Quaternion.identity);
        x.transform.position = new Vector3(x.transform.position.x, x.transform.position.y, 110);
        Destroy(x, 5);
    }
    #endregion

    #region CreateMakeBigger
    private void CreateMakeBigger()
    {
        random = Random.Range(0, spawnPointsCollectables.Length);
        GameObject x = Instantiate(makeBigger, spawnPointsCollectables[random].transform.position, Quaternion.identity);
        x.transform.position = new Vector3(x.transform.position.x, x.transform.position.y, 110);
        Destroy(x, 5);
    }
    #endregion

    #region CreateMakeSmaller
    private void CreateMakeSmaller()
    {
        random = Random.Range(0, spawnPointsCollectables.Length);
        GameObject x = Instantiate(makeSmaller, spawnPointsCollectables[random].transform.position, Quaternion.identity);
        x.transform.position = new Vector3(x.transform.position.x, x.transform.position.y, 110);
        Destroy(x, 5);
    }
    #endregion

    #region CreateCoin
    private void CreateCoin()
    {
        random = Random.Range(0, spawnPointsCollectables.Length);
        GameObject x = Instantiate(coin, spawnPointsCollectables[random].transform.position, Quaternion.identity);
        x.transform.position = new Vector3(x.transform.position.x, x.transform.position.y, 110);
        Destroy(x, 6);
    }
    #endregion
}
