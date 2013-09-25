# Hangeul Romaniser #

**Hangeul Romaniser** provides a library to Romanise Korean syllables (Hangeul) based on the [Romanization of Korean][1] by [the National Institute of the Korean Language](http://www.korean.go.kr/eng_new).


**Hangeul Romaniser**는 한글 음절들을 [국립국어원](http://www.korean.go.kr/09_new)에서 규정한 [한글 로마자 표기규정][2]에 따라 영문으로 변환해주는 라이브러리입니다.



# How It Works #

According to the Unicode table, all Hangeul syllables, initials, medials and finals are listed in an alphabetical order ([Hangul Syllables][hangeul_syllables] and [Hangul Jamo][hangeul_jamo]). So the distance between the initial and the final of a letter can be calculated and its result is used to combine initial, medial and final. In addition to this, by using this approach, a complete syllable can be divided into three distinctive segments &ndash; initial, medial and final. Each segment has its corresponding Romanised alphabet, so splitting a syllable into segments can Romanise the syllable.


유니코드 테이블에 보면 모든 한글 음절, 초성, 중성, 종성들은 가나다 순서로 되어 있습니다. ([한글음절][hangeul_syllables], [한글자모][hangeul_jamo] 참조). 따라서, 한 음절의 초성과 종성 사이의 거리를 계산해낼 수 있기 때문에, 초성, 중성, 종성이 주어지면 이들을 결합하여 해당하는 유니코드 테이블에서 찾을 수 있게 됩니다. 이 방법을 이용하면 마찬가지로 한 음절을 초성, 중성, 종성으로 나눌 수도 있게 됩니다. 초성, 중성, 종성은 각각 로마자 표기규정이 있기 때문에 이들을 조합하면 하나의 음절을 로마자로 변환시킬 수 있게 됩니다.



# Known Issues #

**Hangeul Romaniser** does not currently support the following features:

* Consonants Assimilation
* Contraction
* Fortis (Harder Sound)
* Initial Sound
* Omission
* Palatalisation
* Prolonged Sound
* Vowels Assimilation

**Hangeul Romaniser** currently provides the following features with limitations:

* Substitution


**Hangeul Romaniser**는 아직 아래의 기능을 제공하지 않습니다:

* 된소리법칙
* 구개음화
* 두음법칙
* 모음동화
* 연음법칙
* 음운축약
* 음운탈락
* 자음동화


**Hangeul Romaniser**는 아래의 기능을 제한적으로 제공합니다:

* 음운교체




# License #

**Hangeul Romaniser** is released under [MIT License](http://opensource.org/licenses/MIT).

> The MIT License (MIT)
> 
> Copyright (c) 2013 [aliencube.org](http://aliencube.org)
> 
> Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
> furnished to do so, subject to the following conditions:
> 
> The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
> 
> THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.


**Hangeul Romaniser**는 [MIT 라이센스](http://opensource.org/licenses/MIT)를 따릅니다.

> MIT 라이센스
> Copyright (c) 2013 [aliencube.org](http://aliencube.org)
>  
> 이 소프트웨어의 복제본과 관련된 문서화 파일("소프트웨어")을 획득하는 사람은 누구라도 소프트웨어를 별다른 제한 없이 무상으로 사용할 수 있는 권한을 부여 받는다. 여기에는 소프트웨어의 복제본을 무제한으로 사용, 복제, 수정, 병합, 공표, 배포, 서브라이선스 설정 및 판매할 수 있는 권리와 이상의 행위를 소프트웨어를 제공받은 다른 수취인들에게 허용할 수 있는 권리가 포함되며, 다음과 같은 조건을 충족시키는 것을 전제로 한다.
>  
> 위와 같은 저작권 안내 문구와 본 허용 문구가 소프트웨어의 모든 복제본 및 중요 부분에 포함되어야 한다.
>  
> **이 소프트웨어는 상품성, 특정 목적 적합성, 그리고 비침해에 대한 보증을 포함한 어떠한 형태의 보증도 명시적이나 묵시적으로 설정되지 않은 “있는 그대로의” 상태로 제공된다. 소프트웨어를 개발한 프로그래머나 저작권자는 어떠한 경우에도 소프트웨어나 소프트웨어의 사용 등의 행위와 관련하여 일어나는 어떤 요구사항이나 손해 및 기타 책임에 대해 계약상, 불법행위 또는 기타 이유로 인한 책임을 지지 않는다.**


[1]: http://www.korean.go.kr/eng_new/document/roman/roman_01.jsp
[2]: http://www.korean.go.kr/09_new/dic/rule/rule_roman_0101.jsp
[hangeul_syllables]: http://www.unicode.org/charts/PDF/UAC00.pdf
[hangeul_jamo]: http://www.unicode.org/charts/PDF/U1100.pdf