function JSContactenos(){
    var nombre, correo, asunto, mensaje, expresion;

    var nombre = document.getElementById("nombre").value;
    var correo = document.getElementById("correo").value;
    var asunto = document.getElementById("asunto").value;
    var mensaje = document.getElementById("mensaje").value;
    expresion1= /\w+@\w+\.+[a-z]/;

    if(nombre == 0 ){
        alert("Debe Escribir su Nombre")
        return false;
    }
    if(nombre.length>20){
        alert("Escriba un nombre valido")
        return false;
    }
   
    if(correo == 0 ){
        alert("Debe Escribir su Correo")
        return false;
    }
    if(!expresion1.test(correo)){
        alert("Escriba un Correo valido")
        return false;
    }
     if(asunto == 0 ){
        alert("Debe Escribir un  asunto")
        return false;
    }
    if(asunto.length>30 ){
        alert("Debe Escribir un asunto valido")
        return false;
    }


    if(mensaje == 0 ){
        alert("Debe Escribir su mensaje")
        return false;
    }
    if(mensaje.length>150 ){
        alert("Debe Escribir un mensaje valido")
        return false;
    }
}