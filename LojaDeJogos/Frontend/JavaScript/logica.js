document.addEventListener('DOMContentLoaded', function main() { 
    ecraCategorias();
});

////Categorias
function ecraCategorias() {
    return getCategorias()
        .then(function (categorias) {
            mostraCategorias(categorias);
        })
        .catch(function (erro) {
            console.error(erro);
        });
}

//Percorrer e mostrar todas as categorias
function mostraCategorias(categorias) {
    for (var i = 0; i < categorias.length; i++) {
        var categ = document.createElement("div");
        categ.appendChild(document.createTextNode(categorias[i].Nome));
        categ.id = categorias[i].ID;
        categ.addEventListener("click", function () {
            trocarEcraJog(this.id);
        });
        document.querySelector("#ListaCateg").appendChild(categ);
    }
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////Jogos
function mostraJogos(id) {
    return getJogosCat(id)
        .then(function (jogos) {
            backToCat();
            for (var i = 0; i < jogos.length; i++) {
                var pil = document.createElement("div");
                pil.appendChild(document.createTextNode(jogos[i].nome + " - " + jogos[i].capa));
                document.querySelector("#ListaPil").appendChild(pil);
                ecraPilImg(jogos[i].id);
            }
        })
        .catch(function (erro) {
            console.error(erro);
        });
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
////Mudar ecra

function trocarEcraJog(id) {
    document.querySelector("#ListaCateg").style = "display: none;";
    document.querySelector("#ListaJogos").style = "display:;";
    mostraJogos(id);
}

function trocarEcraDet(id) {
    document.querySelector("#ListaJogos").style = "display: none;";
    document.querySelector("#ListaJogos").style = "display:;";
    document.querySelector("#Nome").style = "display: none;";
    document.querySelector("#Fotografia").style = "display: none;";
    document.querySelector("#Detalhes").style = "display: none;";
    //mostraJogosDet(id);
}

function backToCat() {
    var btn = document.createElement("BUTTON");
    btn.appendChild(document.createTextNode("Back"));
    document.querySelector("#ListaJogos").appendChild(btn);
    btn.addEventListener("click", function () {
        document.querySelector("#ListaCateg").style = "display:;";
        document.querySelector("#ListaJogos").innerHTML = "";
    });
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///ListaJogos

function mostraJogos(id) {
    return getJogosCat(id)
        .then(function (listJog) {
            backToCat();
            var i = 0;
            for (i = 0; i < listJog.jogos.length; i++) {
                var Jnome = document.createElement("div");
                Jnome.appendChild(document.createTextNode(listJog.jogos[i][0]));
                Jnome.id = listJog.jogos[i][1];
                Jnome.addEventListener("click", function () {
                    trocarEcraDet(this.id);
                });

                var img = document.createElement("img");
                img.src = "/media/" + listJog.jogos[i][2];

                var JCapa = document.createElement("div");
                JCapa.appendChild(img);

                document.querySelector("#ListaJogos").appendChild(Jnome);
                document.querySelector("#ListaJogos").appendChild(JCapa);
            }   
        })
        .catch(function (erro) {
            console.error(erro);
        });
}