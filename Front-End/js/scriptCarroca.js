var value = 0

async function validarRequisicao() {
    const rawResponse = await fetch('https://localhost:7294/Produto');
    const texto = await rawResponse.json();
    value = texto.retorno.valorFinal;
    inicializarLoja(texto.retorno.carroca)
}

const inicializarLoja = (texto) => {
    var containerProdutos = document.getElementById('novos');
    texto.map((val) => {
        containerProdutos.innerHTML += `
            <div class="teste">
            <img id="teste" src="${val.src}"/>
            <div id="testeText">
            <p>Nome : ${val.nome}</p>
            <p>Valor Unitário : R$${val.valor}</p></div>
            <div id="infos">
            <p>Quantidade : ${val.quantidade}</p>
            <button onclick="removerItem('${val.id}')">Remover Item</button></div>`
    })
    if(value == 0){
        document.getElementById('valor').innerHTML = "<h2>A carroça está vazia!</h2>";
    }else{
        var formataValor = `<h2>Valor Total: R$ ${value},00</h2>`
        document.getElementById('valor').innerHTML = formataValor;
    }
}
validarRequisicao();



async function removerItem(Id) {

    const inputDados = {
        "Id": Id,
    }

    const rawResponse = await fetch('https://localhost:7294/Produto', {
        method: 'DELETE',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(inputDados)
    });
    location.reload();
}