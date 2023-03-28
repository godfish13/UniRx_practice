# UniRx_practice
 
 !!! start 혹은 awake에서 subscribe해야 하나의 스트림만 생성한다. if) update내에서 subscribe시, 프레임마다 스트림을 생성해버림
 
~~.AsObservable()  <-이벤트를 스트림으로 변경

.AsObservable().Subscribe(streaminput => { 실행문 });  <- 스트림을 구독, 최종적으로 무엇을 할 것인가 작성

.OnClickAsObservable().SubscribeToText(text, input => "Clicked");   <-  unirx에는 이처럼 uGUI용 Observe와 Subscribe가 준비되어 있음
                                                                        (단, text가 legacy text형식임 TextMeshPro 사용 불가)
