var total = [];

function enFunksjon(){
    var input2;
    if(total.length > 0){
        input2 = total.slice(-1);   
    }
    if (input2 === this.value && this.value === "*"){
        console.log(input2 + " duplicate " + this.value);
    }
    else  {
        console.log( this.value + " " + input2);
        $('#display').val(total + this.value);
        total+= this.value;
    }

}

function evaluate() {

    
    if(total.length > 0){
        total=eval(total);
        $('#display').val(total);
    }
}

function clear() {
    if(total.length > 0){
        total = total.slice(0, -1);
        $('#display').val(total);
    }
}

function reset() {
    total=[];
    $('#display').val(total);
}
