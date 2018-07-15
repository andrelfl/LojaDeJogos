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
function mostraJogosDet(id) {
    return getJogDet(id)
        .then(function (jogo) {
            backToList();

            var img = document.createElement("img");
            img.src = "/media/" + jogo.Capa;

            var h1 = document.createElement("h1");
            h1.appendChild(document.createTextNode(jogo.Nome));
            document.querySelector("#Nome").appendChild(h1);
            document.querySelector("#Fotografia").appendChild(img);
            document.querySelector("#Detalhes").appendChild(document.createTextNode(jogo.Descricao));

            var divO = document.createElement("div");
            divO.class = "row";
            divO.style = "overflow-x:auto;height:220px; white-space:nowrap";
            divO.id = "divO";

            for (var i = 0; i < jogo.listaMedia.length; i++){
                var divI = document.createElement("div");
                divI.id = "divI";
                divI.class = "col-lg-4 col-md-4 col-sm-6";
                divI.style = "display:inline-block; float:none";
                var img = document.createElement("img");
                img.src = "/media/" + jogo.listaMedia[i][1];
                img.style = "height:200px";
                divI.appendChild(img);
                divO.appendChild(divI);
            }

            document.querySelector("#Media").appendChild(divO); 
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
    document.querySelector("#DetJog").style = "display:;";
    mostraJogosDet(id);
}

function backToCat() {
    var btn = document.createElement("BUTTON");
    btn.appendChild(document.createTextNode("Back"));
    btn.class = "btn btn-info";
    var div = document.createElement("div");
    div.appendChild(btn);
    document.querySelector("#ListaJogos").appendChild(div);
    btn.addEventListener("click", function () {
        document.querySelector("#ListaCateg").style = "display:;";
        document.querySelector("#ListaJogos").innerHTML = "";
    });
}

function backToList() {
    var btn = document.createElement("BUTTON");
    btn.appendChild(document.createTextNode("Back"));
    btn.class = "btn btn-info";
    var div = document.createElement("div");
    div.id = "Back";
    div.appendChild(btn);
    document.querySelector("#Nome").appendChild(div);
    btn.addEventListener("click", function () {
        document.querySelector("#ListaJogos").style = "display:;";
        document.querySelector("#Nome").innerHTML = "";
        document.querySelector("#Fotografia").innerHTML = "";
        document.querySelector("#Detalhes").innerHTML = "";
        document.querySelector("#Media").innerHTML = "";
    });
}

///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
///ListaJogos

function mostraJogos(id) {
    return getJogosCat(id)
        .then(function (listJog) {
            backToCat();
            var i = 0;
            var div = document.createElement("div");
            div.id = "Cards";
            div.className = "card-columns";
            for (i = 0; i < listJog.jogos.length; i++) {
                var card = document.createElement("div");
                var cardB = document.createElement("div");
                card.className = "card";
                card.style = "width: 400px;";
                cardB.className = "card-body";

                var title = document.createElement("h5");
                title.className = "card-title";
                title.appendChild(document.createTextNode(listJog.jogos[i][0]));
                title.id = listJog.jogos[i][1];

                var desc = document.createElement("p");
                desc.className = "card-text";
                desc.appendChild(document.createTextNode(listJog.jogos[i][4] + " €"));

                cardB.appendChild(title);
                cardB.appendChild(desc);

                ///
                title.addEventListener("click", function () {
                    trocarEcraDet(this.id);
                });
                ////

                var img = document.createElement("img");
                img.src = "/media/" + listJog.jogos[i][2];
                img.className = "card-img-top";

                card.appendChild(img);
                card.appendChild(cardB);

                div.appendChild(card);
            }
            document.querySelector("#ListaJogos").appendChild(div);
        })
        .catch(function (erro) {
            console.error(erro);
        });
}