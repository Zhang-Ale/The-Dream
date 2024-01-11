using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTimeScale : MonoBehaviour
{
    public float SpeedScale = 50;
    public Transform PlayerTransform; 
    [Space(10)]
    public float ActualTimeScale = 1;
    [Header("Debug Vars")]
    public float Speed;
    void Start()
    {
        StartCoroutine(SpeedTester());
    }
    void Update()
    {
        //con Mathf.Clamp01(), il calcolo dentro la parentesi avrà un risultato da 0 a 1
        ActualTimeScale = Mathf.Clamp01(Speed / SpeedScale); 

        Time.timeScale = ActualTimeScale;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;
    }
    IEnumerator SpeedTester()
    {
        Vector3 oldPosition = PlayerTransform.position;
        //while (true)=per sempre
        while (true)
        {
            //se mettessi niente dentro "while(true)", va alla MAX velocità del processore
            //con "yield return" manda un valore di ritorno al coroutine

            //io salvo la mia vecchia posizione, aspetto 0.02f (1/0.02=50 aggiornamenti al secondo), 
            //e la mia velocità in magnitude (trasforma un Vector3 diverso da 0 in un float)
            oldPosition = PlayerTransform.position; 
            yield return new WaitForSecondsRealtime(0.02f);
            Speed = Vector3.Distance(oldPosition, PlayerTransform.position);
            //La riga sopra equivale a: Speed = Mathf.Abs ((PlayerTransform.position - oldPosition).magnitude); 
            //Con Mathf.Abs(), il calcolo dentro la parentesi viene ignorato il segno, che sia + o -, diventa sempre un valore positivo

            /*Ogni secondo nel mio game stampa un Ciao, controlla il timing del mio gioco
            print("Ciao");
            yield return new WaitForSeconds(1); 
             
            WaitForSecondsRealtime controlla il timing del mio computer
            print("Ciao");
            yield return new WaitForSecondsRealtime(1); 
            
            Pensa se settiamo la MAX durata del gicoo in 20sec e over questa durata il giocatore perde,
            se il giocatore non muove il tempo freeza. Con WaitForSeconds, it tempo freeza.
            Invece con il WaitForSecondsRealtime, il tempo continuerebbe a passare anche se il giocatore stia fermo.
            */
        }
    }
}

/*Update è instabile e rappresenta aggiornamento dei frame cioè di quello che vediamo sullo schermo, 
il FixedUpdate rappresenta l'update fisico,
il Coroutine rappresenta un update indipendente che scegliamo noi quando avviene. */
