# Wstęp - "Czy jedzie mi tu czołg?"

## Materiały:

* [Unity Essentials](https://unity3d.com/learn/tutorials/topics/interface-essentials)
* [Strona z oficjalnymi tutorialami Unity](https://unity3d.com/learn/tutorials)
* [Dokumentacja Unity (CZYTAJCIE ZAWSZE KIEDY MACIE WĄTPLIWOŚCI!)](https://docs.unity3d.com/ScriptReference/index.html)
* [Wstęp do Unity by Sebastian Lague](https://www.youtube.com/playlist?list=PLFt_AvWsXl0fnA91TcmkRyhhixX9CO3Lw)
* [Wstęp do Cinemachine](https://www.youtube.com/watch?v=Gx9gZ9cfrys)
* [Wykład o Cinemachine, Unite 2017](https://www.youtube.com/watch?v=r1SkOoJJRAA)
* [Przegrani!](https://www.youtube.com/channel/UCeRQEfSlTJeh0nezitDIigw)
* [Co to są Game Jamy? - polecam](https://youtu.be/NUY7pMJ5WPw)
* [Game Jamy: Jak z nich skorzystać?](https://youtu.be/a27EdTowVYo)

## Zadania:

### Dla ćwiczeń warto wykonać poniższe zadania. Jeżeli się będziesz miał jakieś trudności, każde z nich jest zrobione w folderze "3. Tasks Completed".

* Zmień sposób sterowania czołgiem na trochę bardziej cywilizowany,
czyli poruszamy się przód-tył klawiszami WS (lub strzałki góra, dół), a obracamy czołg wokół własnej osi klawiszami AD (lub prawo, lewo).
* Zmodyfikuj CannonController tak, aby mógł przyjąć więcej prefabów pocisku (tablica albo lista) i w momencie strzału losowało prefab, który ma być instancjonowany. Co się z tym wiąże, stwórz także więcej prefabów pocisków, które różnią się wyglądem i prędkością.
* Stwórz nowy skrypt ExplosiveBullet, który jak sama nazwa wskazuje, ma wybuchać po zetknięciu z innym obiektem. Skrypt powinien dziedziczyć po Bullet (coby można go było wsadzić do listy zrobionej w punkcie wyżej), a eksplozja odpychać wszystkie obiekty posiadające Rigidbody w zasięgu. Warto użyć metody [Rigidbody.AddExplosionForce()](https://docs.unity3d.com/ScriptReference/Rigidbody.html) i [Physics.OverlapSphere()](https://docs.unity3d.com/ScriptReference/Physics.OverlapSphere.html). 
* Dodaj do TankControler "tryb turbo", czyli chwilowe zwiększenie prędkości poruszania się z pewnym cooldownem pomiędzy kolejnymi użyciami. Będą przydatne [korutyny](https://docs.unity3d.com/Manual/Coroutines.html).
