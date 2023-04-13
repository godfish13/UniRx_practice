# UniRx_practice
 
 Scripts
 
 Click2buttons
 -버튼 두개를 모두 누른경우 인식
 
 ClickVisulize
 -mode // 0 : change text if clicked, 1 : change text if clicked 3 times(use buffer), 2 : change text if clicked 3 times(use skip)
 -모드에 따라 버튼 클릭 시 버튼 텍스트 변경
 
 In folder
 20230402
 -delegate event를 통한 Timer의 제작 vs UniRx를 통한 Timer의 제작
 
 20230405
 -ReactiveProperty, UniRxTriggers, UniRx_Coroutine 세가지 방식으로 subject 만들기
 
 20230407
 -OnNext, OnError, OnCompleted 세가지의 사용방식 예시와 Dispose를 통한 스트림 종료 예시
 
 20230413_RotateCube
 -SkipUntil, TakeUntil, Repeat을 활용하여 오브젝트를 드래그하여 회전시키기 구
 
 
 
 !!! start 혹은 awake에서 subscribe해야 하나의 스트림만 생성한다. if) update내에서 subscribe시, 프레임마다 스트림을 생성해버림
 
.AsObservable()  <-이벤트를 스트림으로 변경(GUI의 button등이 Onclick()이벤트를 보내는 등 이벤트에 바로 연결 가능)

.UpdateAsObservable()  <-지정한 오브젝트에 연동된 스트림 생성(오브젝트가 destroy될 때 OnCompleted 실행)

Observable.EveryUpdate()  <- gameObject로부터 독립된 Observable이 만들어짐, MonoBehaviour에 관계 없는 곳에서도 사용 가능 !!!주의사항 오브젝트 destroy 시 OnCompleted 실행 안됨!

ObserveEveryValueChanged()  <- Observable.EveryUpdate의 파생 버전, 값의 변화를 매프레임 감시하는 Observable 생성

.AsObservable().Subscribe(_ => { 실행문 });  <- 스트림을 구독, 최종적으로 무엇을 할 것인가 작성

.Subscribe(n => 실행문) : onNext(n) 구독   
.Subscribe(ex => 실행문) : onError() 구독 (Excoption ex)   
.Subscribe(() => 실행문) : onCompleted()  (매개변수 없음)   

+) .OnClickAsObservable().SubscribeToText(text, input => "text");   <-  unirx에는 이처럼 uGUI용 Observe와 Subscribe가 준비되어 있음   
                                                                        (단, text가 legacy text형식임 TextMeshPro 사용 불가)

.AsObservable().Buffer(n).Subscribe(streaminput => { 실행문 });  <- 메세지가 n횟수만큼 모이면 실행   
.AsObservable().Skip(n).Subscribe(streaminput => { 실행문 });  <- 메세지를 n횟수만큼 무시하고 이후 메세지 입력 시 실행

Event1.AsObservable().Zip(Event2.AsObservable(), (E1, E2) => output).First().Repeat().Subscribe(streaminput => { 실행문 });   
<- Zip을 통해 Event1, Event2의 입력 두개가 모두 들어오면 하나의 이벤트로 취급해서 보냄, 결과물 output은 임의로 가공 가능   
.First().Repeat() <- 1번 동작 후 Zip내의 버퍼를 클리어   

