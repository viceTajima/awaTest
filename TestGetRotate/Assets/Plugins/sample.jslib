mergeInto(LibraryManager.library, {

  // 関数呼び出し
  Hello: function () {
    window.alert("Hello, world!");
      SendMessage('JsTest', 'ShowRotation', "test1,test2,test3");
  },

  // 数値型の引数と戻り値
  AddNumbers: function (x, y) {
    return x + y;
  },

  // 数値型以外の型の引数
  PrintFloatArray: function (array, size) {
    for(var i = 0; i < size; i++)
      console.log(HEAPF32[(array >> 2) + i]);
  },

  // 文字列型の引数
  HelloString: function (str) {
    window.alert(Pointer_stringify(str));
  },

  // 文字列の戻り値
  StringReturnValueFunction: function () {
    var returnStr = "bla";
    var bufferSize = lengthBytesUTF8(returnStr) + 1;
    var buffer = _malloc(bufferSize);
    stringToUTF8(returnStr, buffer, bufferSize);
    return buffer;
  },

  // WebGLテクスチャのバインド
  BindWebGLTexture: function (texture) {
    GLctx.bindTexture(GLctx.TEXTURE_2D, GL.textures[texture]);
  },
  
  WatchDeviceorientation: function () {
    
      window.addEventListener('deviceorientation', handleOrientation);

      function handleOrientation(event) {
        var xy = event.alpha + "," + event.beta + "," + event.gamma;

        const _euler = new THREE.Euler();
        const _qt = new THREE.Quaternion();
        const beta = THREE.MathUtils.degToRad(event.beta);
        const alpha = THREE.MathUtils.degToRad(event.alpha);
        const gamma = THREE.MathUtils.degToRad(-event.gamma);
        _euler.set(beta, alpha, -gamma, "ZXY");
        _qt.setFromEuler(_euler);
        

        document.getElementById("qtx").innerText = _qt.x;
        document.getElementById("qty").innerText = _qt.y;
        document.getElementById("qtz").innerText = _qt.z;
        document.getElementById("qtw").innerText = _qt.w;


        SendMessage('TestTest', 'TestText2', _qt.x.toString() + "," + _qt.y.toString() + "," + _qt.z.toString() + "," + _qt.w.toString());
        // Do stuff...
      }
  },  

  WatchDevicemotion: function() {
    
      window.addEventListener('devicemotion', handleMotion);

      function handleMotion(event){
        var acceleration = event.acceleration;
        var accelerationIncludingGravity = event.accelerationIncludingGravity;
        var rotationRate = event.rotationRate;

        var teteteR = 1;
        const ua = navigator.userAgent
        if (/android/i.test(ua)) {
          teteteR = 1000;
        }

        
        var testx = parseFloat(document.getElementById("qtx").innerText);
        var testy = parseFloat(document.getElementById("qty").innerText);
        var testz = parseFloat(document.getElementById("qtz").innerText);
        var testw = parseFloat(document.getElementById("qtw").innerText);

        var mux = testx * 2;
        var muy = testy * 2;
        var muz = testz * 2;
        var muxx = testx * mux;
        var muyy = testy * muy;
        var muzz = testz * muz;
        var muxy = testx * muy;
        var muxz = testx * muz;
        var muyz = testy * muz;
        var muwx = testw * mux;
        var muwy = testw * muy;
        var muwz = testw * muz;

        var rex = (1 - (muyy + muzz)) * acceleration.x + (muxy - muwz) * acceleration.y + (muxz + muwy) * acceleration.z;
        var rey = (muxy + muwz) * acceleration.x + (1 - (muxx + muzz)) * acceleration.y + (muyz - muwx) * acceleration.z;
        var rez = (muxz - muwy) * acceleration.x + (muyz + muwx) * acceleration.y + (1 - (muxx + muyy)) * acceleration.z;

        
        document.getElementById("qttx").innerText = rex.toString();
        document.getElementById("qtty").innerText = rey.toString();
        document.getElementById("qttz").innerText = rez.toString();

        SendMessage('TestTest', 'TestText5', rex.toString() + "," + rey.toString() + "," + rez.toString() + "," + event.interval.toString() + "," + teteteR.toString()); 

        //document.getElementById("area1").innerText = acceleration.x;
        //document.getElementById("area2").innerText = acceleration.y;
        //document.getElementById("area3").innerText = acceleration.z;
        //
        //document.getElementById("area4").innerText = accelerationIncludingGravity.x;
        //document.getElementById("area5").innerText = accelerationIncludingGravity.y;
        //document.getElementById("area6").innerText = accelerationIncludingGravity.z;
        //
        //SendMessage('TestTest', 'TestText3', acceleration.x.toString() + "," + acceleration.y.toString() + "," + acceleration.z.toString() + "," + event.interval.toString() + "," + document.getElementById("g").value + "," + document.getElementById("h").value + "," + teteteR.toString());
      }
  },

  GetGeolocation: function(){

    if(navigator.geolocation){
        var options = {
          enableHighAccuracy: true,
          timeout: 6000,
          maximumAge: 600000
        };
        navigator.geolocation.getCurrentPosition(successCallback, errorCallback, options);
    }else{
        SendMessage('TestTest', 'TestText1');
    }

    function successCallback(position) {
        var latitude = "0";
        var longitude = "0";
        var altitude = "0";
        var accuracy = "0";
        var altitudeAccuracy = "0";

        if(position.coords == null){
            latitude = "0";
            longitude = "0";
            altitude = "0";
            accuracy = "0";
            altitudeAccuracy = "0";
        }else{
            if(position.coords.latitude == null){
            }else{
                latitude = position.coords.latitude.toString();
            }
            if(position.coords.longitude == null){
            }else{
                longitude = position.coords.longitude.toString();
            }
            if(position.coords.altitude == null){
            }else{
                altitude = position.coords.altitude.toString();
            }
            if(position.coords.accuracy == null){
            }else{
                accuracy = position.coords.accuracy.toString();
            }
            if(position.coords.altitudeAccuracy == null){
            }else{
                altitudeAccuracy = position.coords.altitudeAccuracy.toString();
            }
        }

        SendMessage('TestTest', 'TestText4', latitude + "," + longitude + "," + altitude + "," + accuracy + "," + altitudeAccuracy);
    }

    function errorCallback(error) {
      var err_msg = "";
      switch(error.code)
      {
        case 1:
          err_msg = "itijyouhounoriyougakyokasareteimasen位置情報の利用が許可されていません";
          break;
        case 2:
          err_msg = "devicenoitigahannteidekimasennデバイスの位置が判定できません";
          break;
        case 3:
          err_msg = "timeoutタイムアウトしました";
          break;
      }
        window.alert(err_msg);
        SendMessage('TestTest', 'TestText1');
    }
  },

  TestGetGyro: function(){
    return "GGGGGGGGG";
  },

});