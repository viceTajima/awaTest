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
        
        SendMessage('TestTest', 'TestText3', acceleration.x.toString() + "," + acceleration.y.toString() + "," + acceleration.z.toString() + "," + event.interval.toString() + "," + document.getElementById("g").value + "," + document.getElementById("h").value);
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

        document.getElementById("area1").innerText = latitude;
        document.getElementById("area2").innerText = longitude;
        document.getElementById("area3").innerText = altitude;
        document.getElementById("area4").innerText = accuracy;
        document.getElementById("area5").innerText = altitudeAccuracy;

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