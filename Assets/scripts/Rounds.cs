using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//David Oscar Bohez
public class Rounds : MonoBehaviour
{
    public Vector3 center;
    public Vector3 size;
    public GameObject enemy;
    public GameObject boss;
    public GameObject knight;
    public GameObject hammer;
    public GameObject lance;
    public Text txtround;
    //number of enemies
    public int cont;
    public int contKills;
    public int round;
    public float baseLife=20;
    public float baseLifeBoss = 150;
    int probability;

    // Start is called before the first frame update
    void Start()
    {
        center = transform.position;
        Spawn();
        cont = 7;
        round = 1;
    }

    // Update is called once per frame
    void Update()
    {
        txtround.text="Round: "+round;
        //cuenta rondas FUNCIONA
        cont = cont;
        //cuenta kill FUNCIONA
        contKills = contKills;
        //paso los datos a la pantalla final
        Punctuation.En = contKills;
        Punctuation.Ro = round;

        if (cont <= 0)
        {
            Spawn();
            round++;
        }
    }

    public void Spawn()
    {

        if (round >= 0 && round < 10)
        {
            for (int i = 0; i < 7; i++)
            {
                probability = Random.Range(0, 40);
                SpawnEnemy(probability);
            }
            cont = 7;
        }
        else if (round >= 10 && round < 20)
        {
            if (round == 10)
            {
                //Spawn boss
                SpawnBoss();
                cont = 1;
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    probability = Random.Range(0, 30);
                    SpawnEnemy(probability);
                }
                cont = 7;
            }
        }
        else if (round >= 20 && round < 30)
        {
            if (round == 20)
            {
                //Spawn boss
                SpawnBoss();
                cont = 1;
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    probability = Random.Range(0, 20);
                    SpawnEnemy(probability);
                }
                cont = 7;
            }
        }
        else if (round >= 30 && round < 40)
        {
            if (round == 30)
            {
                //Spawn boss
                SpawnBoss();
                cont = 1;
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    probability = Random.Range(0, 15);
                    SpawnEnemy(probability);
                }
                cont = 7;
            }
        }
        else if (round >= 40 && round < 50)
        {
            if (round == 40)
            {
                //Spawn boss
                SpawnBoss();
                cont = 1;
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    probability = Random.Range(0, 12);
                    SpawnEnemy(probability);
                }
                cont = 7;
            }
        }
        else
        {
            if (round % 10 == 0)
            {
                //Spawn boss
                SpawnBoss();
                cont = 1;
            }
            else
            {
                for (int i = 0; i < 7; i++)
                {
                    probability = Random.Range(0, 10);
                    SpawnEnemy(probability);
                }
                cont = 7;
            }
        }

    }

    //espawnea los enemigos recibiendo la probabilidad
    public void SpawnEnemy(int probability)
    {
        switch (probability)
        {
            case (7):
                //enemigo medio
                Vector3 pos4 = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
                lance.gameObject.GetComponent<HealthEnemy>().max_health = EnemyLife();
                //lance.gameObject.GetComponent<EnemyAttack>().damage = DamageEnemies();
                Instantiate(lance, pos4, Quaternion.identity);
                break;
            case (5):
                //enemigo medio-hard
                Vector3 pos3 = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
                hammer.gameObject.GetComponent<HealthEnemy>().max_health = EnemyLife();
                //hammer.gameObject.GetComponent<EnemyAttack>().damage = DamageEnemies();
                Instantiate(hammer, pos3, Quaternion.identity);
                break;
            case (2):
                //enemigo hard
                Vector3 pos2 = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
                hammer.gameObject.GetComponent<HealthEnemy>().max_health = EnemyLife();
                //hammer.gameObject.GetComponent<EnemyAttack>().damage = DamageEnemies();
                Instantiate(hammer, pos2, Quaternion.identity);
                break;
            default:
                Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
                enemy.gameObject.GetComponent<HealthEnemy>().max_health = EnemyLife();
                //enemy.gameObject.GetComponent<EnemyAttack>().damage = DamageEnemies();
                Instantiate(enemy, pos, Quaternion.identity);
                break;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(center,size);
    }

    /*public void Spawn()
    {
        for (int i = 0; i < 7; i++)
        {
            Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
            Instantiate(enemy, pos, Quaternion.identity);
        }
    }*/

    public void SpawnBoss()
    {
        
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        boss.gameObject.GetComponent<HealthEnemy>().max_health = BossLife();
        //boss.gameObject.GetComponent<EnemyAttack>().damage = DamageEnemies();
        Instantiate(boss, pos, Quaternion.identity);
        
    }

    //Nuevos metodos
    //Calcular la vida de los enemigos segun la ronda, para ajustar la dificultad 
    public float EnemyLife()
    {
        float x = 0f;
        x = baseLife + (round * 1.5f); //antes usaba 2 y fue 1.7f
        return x;
    }
    //Calcular el numero de enemigos segun la ronda
    public int NumberEnemies()
    {
        int x = 0;
        x = 7 + (round / 10);
        return x;
    }
    //Calcular la vida de los boses segun la ronda, para ajustar la dificultad 
    public float BossLife()
    {
        float x = 0;
        x = baseLifeBoss + (round * 2);
        return x;
    }

    //el daño dependera de la ronda por la que este el jugador
    public float DamageEnemies()
    {
        float x = 0f;

        if (round >= 10)
        {
            x = 15f;
        }else if (round >= 20)
        {
            x = 20f;
        }
        else if (round >= 30)
        {
            x = 30f;
        }
        else if (round >= 40)
        {
            x = 40f;
        }
        else if (round >= 50)
        {
            x = 50f;
        }
        else if (round >= 60)
        {
            x = 60f;
        }
        else if (round >= 70)
        {
            x = 70f;
        }
        else if (round >= 80)
        {
            x = 80f;
        }
        else if (round >= 90)
        {
            x = 90f;
        }
        else if (round >= 100)
        {
            x = 100f;
        }
        else
        {
            x = 10f;
        }
        
        return x;
    }


}
