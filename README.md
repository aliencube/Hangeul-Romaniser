# Hangeul Romaniser #

**Hangeul Romaniser** provides a library to Romanise Korean syllables (Hangeul) based on the [Romanization of Korean][romanising_en] by [the National Institute of the Korean Language][nikl_en].


**Hangeul Romaniser**는 한글 음절들을 [국립국어원][nikl_ko]에서 규정한 [한글 로마자 표기규정][romanising_ko]에 따라 영문 로마자로 변환해주는 라이브러리입니다.



# How It Works #

In Korean characters, a syllable consists of three phonemes &ndash; initial, medial and final. By combining these phonemes, any syllable can be generated and/or any syllable can be split into three phonemes ([Korean Word Structure and Basic Letters][korean_word_structure]). The Unicode table contains all Korean syllables and phonemes. With this table, when phonemes are given, a syllable can be found and/or vice versa ([Understanding Korean Encoding (written in Korean)][rule]). In addition to this, [Romanization of Korean][romanising_en] also determines each phoneme has its own Romanised string equivalent. Therefore, with combination of all these, any Korean syllable can be Romanised.

한국어 글자에서 하나의 음절은 초성, 중성, 종성의 세가지 음소로 나눌 수 있습니다. 반대로 초성, 중성, 종성의 세 음소를 결합하면 하나의 음절을 만들 수 있습니다. ([한국어 음절 구조 (영문)][korean_word_structure] 참조). 유니코드 테이블은 한국어에서 사용 가능한 모든 음절과, 음소들을 포함하고 있고, [이 원리][rule]를 이용하면 초성, 중성, 종성이 주어질 때 해당하는 음절을 찾을 수 있고, 그 반대로 음절에서 음소로 분리도 가능합니다. 각각의 음소는 [한글 로마자 표기규정][romanising_ko]을 따라 해당하는 영문 로마자들이 있으므로 이를 이용한다면 어떤 한글 단어 혹은 음절이 주어질 때 이를 영문 로마자로 변환시킬 수 있습니다.



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


[romanising_en]: http://www.korean.go.kr/eng_new/document/roman/roman_01.jsp
[romanising_ko]: http://www.korean.go.kr/09_new/dic/rule/rule_roman_0101.jsp
[nikl_en]: http://www.korean.go.kr/eng_new
[nikl_ko]: http://www.korean.go.kr/09_new
[korean_word_structure]: http://www.howtostudykorean.com/unit0/unit0lesson1
[hangeul_syllables]: http://www.unicode.org/charts/PDF/UAC00.pdf
[hangeul_jamo]: http://www.unicode.org/charts/PDF/U1100.pdf
[rule]: http://helloworld.naver.com/helloworld/76650