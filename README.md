# UniRx_practice
 
 !!! start 혹은 awake에서 subscribe해야 하나의 스트림만 생성한다. if) update내에서 subscribe시, 프레임마다 스트림을 생성해버림
 
~~.AsObservable()  <-이벤트를 스트림으로 변경

.AsObservable().Subscribe(streaminput => { 실행문 });  <- 스트림을 구독, 최종적으로 무엇을 할 것인가 작성

.Subscribe(n => 실행문) : onNext(n) 전달
.Subscribe(ex => 실행문) : onError() 전달 (Excoption ex)
.Subscribe(() => 실행문) : onCompleted() 전달 (매개변수 없음)

+) .OnClickAsObservable().SubscribeToText(text, input => "Clicked");   <-  unirx에는 이처럼 uGUI용 Observe와 Subscribe가 준비되어 있음
                                                                        (단, text가 legacy text형식임 TextMeshPro 사용 불가)

.AsObservable().Buffer(n).Subscribe(streaminput => { 실행문 });  <- 메세지가 n횟수만큼 모이면 실행
.AsObservable().Skip(n).Subscribe(streaminput => { 실행문 });  <- 메세지를 n횟수만큼 무시하고 이후 메세지 입력 시 실행

Event1.AsObservable().Zip(Event2.AsObservable(), (E1, E2) => output).First().Repeat().Subscribe(streaminput => { 실행문 });
<- Zip을 통해 Event1, Event2의 입력 두개가 모두 들어오면 하나의 이벤트로 취급해서 보냄, 결과물 output은 임의로 가공 가능
.First().Repeat() <- 1번 동작 후 Zip내의 버퍼를 클리어
