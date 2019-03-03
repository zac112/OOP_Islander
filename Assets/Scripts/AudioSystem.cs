using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AudioSystem : MonoBehaviour, IAction
{

    [SerializeField]
    private List<AudioClip> musics = new List<AudioClip>();

    [SerializeField]
    private AudioSource ac = null;
    
    // Start is called before the first frame update
    
    void Start()
    {

        foreach (EventType x in System.Enum.GetValues(typeof(EventType)))
        {
            EventSystem.AddEvent(x, this);
        }
        React(EventType.GameStarts);
    }

    
    public void React(EventType type) {
        if (type == EventType.GameStarts)
        {
            GameStartsClip();
        }
        if (type == EventType.CitySmall)
        {
            CitySmallClip();
        }
        if (type == EventType.CityBig)
        {
            CityBigClip();
        }
        if (type == EventType.HuntingSmall)
        {
            HuntingSmallClip();
        }
        if (type == EventType.HuntingBig)
        {
            HuntingBigClip();
        }
        if (type == EventType.WoodChopped)
        {
            WoodClip();
        }
        if (type == EventType.StoneCut)
        {
            StoneClip();
        }
        if (type == EventType.Berrypicked)
        {
            BerryClip();
        }
        if (type == EventType.UpgradeBuilt)
        {

        }
        if (type == EventType.TimePeriodChanged)
        {

        }
        
    }


    public void GameStartsClip()
    {
        StartCoroutine("FadeOutIn", new Timing(2,1));
        StartCoroutine("PlayEffect", 6);
    }
    public void CitySmallClip()
    {
        StartCoroutine("FadeOutIn", new Timing(3, 1));
    }
    public void CityBigClip()
    {
        StartCoroutine("FadeOutIn", new Timing(3, 2));
    }
    public void HuntingSmallClip()
    {
        StartCoroutine("FadeOutIn", new Timing(2, 4));
    }
    public void HuntingBigClip()
    {
        StartCoroutine("FadeOutIn", new Timing(2, 6));
    }
    public void WoodClip()
    {
        StartCoroutine("PlayEffect", 7);
    }
    public void StoneClip()
    {
        StartCoroutine("PlayEffect", 8);
    }
    public void BerryClip()
    {
        StartCoroutine("PlayEffect", 9);
    }

    IEnumerator FadeOutIn(Timing t) {
        //yield return FadeOut(t.duration);
        yield return StartCoroutine("FadeOut", t.duration);
        ac.clip = musics[t.clip];
        yield return StartCoroutine("FadeIn", t.duration);
    }

    public IEnumerator FadeOut(int duration)
    {
        float start = Time.time;
        float end = start + duration;
        if (ac.isPlaying)
        {
            while (Time.time < end)
            {
                float current = Time.time - start;
                //(duration-(current-min)/(max-min)
                float volume = (duration - (Time.time - start)) / (end - start);
                yield return null;
                ac.volume = volume;
            }
            ac.Stop();
        }
    }
    public IEnumerator FadeIn(int duration)
    {
        float start = Time.time;
        float end = start + duration;
        ac.volume = 0;
        ac.Play();
        while(Time.time < end)
        {
            float current = Time.time - start;
            //(max-current)/(max-min)
            float volume = (Time.time - start) / (end - start);
            yield return null;
            ac.volume = volume;
        }
        ac.volume = 1;
    }
    public IEnumerator PlayEffect(int clip)
    {
        AudioSource v = gameObject.AddComponent<AudioSource>();
        v.clip = musics[clip];
        v.Play();
        yield return new WaitForSeconds(v.clip.length + 1);
        Destroy(v);
    }



    private class Timing {
        public int clip;
        public int duration;

        public Timing(int duration, int clip) {
            this.clip = clip;
            this.duration = duration;
        }
    }




}
