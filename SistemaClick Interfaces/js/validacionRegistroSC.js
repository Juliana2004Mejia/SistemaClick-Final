function validarregistro(){
    var nombres, apellidos, correo, usuario, contraseña, telefono, direccion, expresion;

    var nombres = document.getElementById("nombres").value;
    var apellidos = document.getElementById("apellidos").value;
    var correo = document.getElementById("correo").value;
    var usuario = document.getElementById("usuario").value;
    var contraseña = document.getElementById("contraseña").value;
    var telefono = document.getElementById("telefono").value;
    var direccion = document.getElementById("direccion").value;
expresion1= /\w+@\w+\.+[a-z]/;

    if(nombres == 0 ){
        alert("Debe Escribir su Nombre")
        return false;
    }
    if(nombres.length>20){
        alert("Su nombre no debe tener más de 20 caracteres")
        return false;
    }
    if(apellidos == 0 ){
        alert("Debe Escribir sus Apellidos")
        return false;
    }
    if(apellidos.length>20){
        alert("Su apellido no debe tener más de 20 caracteres")
        return false;
    }
   
    if(correo == 0 ){
        alert("Debe Escribir su Correo")
        return false;
    }
    if(!expresion1.test(correo)){
        alert("Escriba un Correo válido")
        return false;
    }

    if(usuario== 0 ){
        alert("Debe Escribir su Usuario")
        return false;
    }

    if (usuario.length>15) 
    {
        alert("Su nombre de usuario no debe tener más de 15 caracteres")
        return false;
    }
   
    if(contraseña == 0 ){
        alert("Debe Escribir su Contraseña")
        return false;
    }

     if(telefono == 0 ){
        alert("Debe Ingresar su numero de telefono  ")
        return false;
    }
    if(telefono.length >10 ){
        alert("Su teléfono debe tener 10 dígitos  ")
        return false;
    }

    if(isNaN(telefono)){
        alert("Debe Escribir Numeros")
    }

    if(direccion == 0 ){
        alert("Debe Escribir su Direccion")
        return false;
    }

    if (direccion.length>40) {
        alert("Escriba un direccion con menos de 40 caracteres")
        return false;
    }
   
}