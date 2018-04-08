# UI i Audio - "Programowanie gier jest ogólnie fajne, poza jednym wyjątkiem"

## Materiały:

* [Oficjalny tutorial Unity o UI](https://unity3d.com/learn/tutorials/topics/interface-essentials/interface-overview)
* [Oficjalny tutorial Unity o Audio](https://unity3d.com/learn/tutorials/topics/audio/audio-listeners-sources?playlist=17096)
* [Łatwy w użyciu system menu (Unite 2017)](https://www.youtube.com/watch?v=wbmjturGbAQ)
* [Ogólnie o UI w Unity (Unite 2017)](https://youtu.be/j03EKMmlJJs)
* [Proste menu z użyciem Text Mesh Pro](https://youtu.be/zc8ac_qUXQY)

Niestety nie znam więcej dobrych materiałów pokrywających te tematy
## Zadania:

### Kappa

* Zbuduj odpowiednie UI na scenie głównej. Powinno odpowiednio się skalować, na ten moment nie musi być funkcjonalne (w sumie na razie nie ma po co...). Może zawierać pasek zdrowia, czas gry, punkty, etc.

* Dodaj do interfejsu jakiś obiekt informujący o stanie "turbo", jeżeli zrobiłeś je na timerach, zrób slider, który zjeżdża do zera gdy tryb jest uruchomiony i wzrasta, gdy mija cooldown. Jeżeli zrobiłeś na korutynach (jak ja) to wystarczy zwykły obrazek zmieniający kolor (zielony - gotowy, niebieski - aktywny, czerwony - cooldown), ponieważ inaczej może być dość trudno.

*  Spróbuj zmiksować dźwięk silnika. Gdy się nie ruszamy słychać tylko EngineIdle, gdy ruszamy dźwięk przechodzi tylko na EngineDriving. Najprościej zrobić to używając dwóch źródeł dźwięku i zmieniać im parametr volume, Mathf.Lerp twoim przyjacielem.

* Spróbuj zrobić menu pauzy z dwoma przyciskami: powrót do gry i menu główne. Przy tej okazji trzeba rozwiązać parę problemów jak wstrzymanie czasu gry, oraz duplikat muzyki za każdym razem, gdy wchodzimy do menu (mówiłem, że DontDestroyOnLoad jest złe :P).