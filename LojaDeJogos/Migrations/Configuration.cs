namespace LojaDeJogos.Migrations
{
    using lojaJogos.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<LojaDeJogos.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(LojaDeJogos.Models.ApplicationDbContext context)
        {
           var categorias = new List<Categorias> {
                new Categorias {ID=1, Nome="Action", Descricao="Action games emphasize physical challenges that require eye-hand coordination and motor skill to overcome. They center around the player, who is in control of most of the action. Most of the earliest video games were considered action games; today, it is still a vast genre covering all games that involve physical challenges. Action games are classified by many subgenres. Platform games and fighting games are among the best-known subgenres, while shooter games became and continue to be one of the dominant genres in video gaming since the 1990s. Action games usually involve elements of twitch gameplay."},
                new Categorias {ID=2, Nome="Adventure", Descricao="Adventure games were some of the earliest games created, beginning with the text adventure Colossal Cave Adventure in the 1970s. That game was originally titled simply 'Adventure', and is the namesake of the genre. Over time, graphics have been introduced to the genre and the interface has evolved. Unlike adventure films, adventure games are not defined by story or content. Rather, adventure describes a manner of gameplay without reflex challenges or action. They normally require the player to solve various puzzles by interacting with people or the environment, most often in a non-confrontational way. It is considered a 'purist' genre and tends to exclude anything which includes action elements beyond a mini game."},
                new Categorias {ID=3, Nome="Strategy", Descricao="Strategy video games focus on gameplay requiring careful and skillful thinking and planning in order to achieve victory and the action scales from world domination to squad-based tactics. In most strategy video games, says Andrew Rollings, 'the player is given a godlike view of the game world, indirectly controlling the units under his command'. Rollings also notes that 'The origin of strategy games is rooted in their close cousins, board games'. Strategy video games generally take one of four archetypal forms, depending on whether the game is turn-based or real-time and whether the game's focus is upon strategy or tactics. Real time strategy games are often a multiple unit selection game (multiple game characters can be selected at once to perform different tasks, as opposed to only selecting one character at a time) with a sky view (view looking down from above) but some recent games such as Tom Clancy's EndWar, are single unit selection and third person view. Like many RPG games, many strategy games are gradually moving away from turn-based systems to more real-time systems."},
                new Categorias {ID=4, Nome="Casual", Descricao="Casual games are designed to be easily picked up and put down again, allowing for potentially short bursts of play, such as Call of Duty and most games on a mobile platform. This genre of gaming is meant to be a short and relaxing pastime, a rest in between other occupations and so is most popular with demographics who have less free time. For this reason the games often have auto-saving and syncing as standard so the games can be minimised, put into sleep or otherwise put down with no loss to the player. Market leaders in this genre are often boldly coloured, designed for intuitive interaction and have a high balance of reward to time to keep people coming back. Designers of these games should add a lot of 'juice' (sound and motion elements that excite the senses) to make them stand out in a sea of highly similar games."},
                new Categorias {ID=5, Nome="Simulation", Descricao="Simulation video games is a diverse super-category of games, generally designed to closely simulate aspects of a real or fictional reality."},
                new Categorias {ID=6, Nome="RPG", Descricao="Role-playing video games draw their gameplay from traditional [not always] role-playing games like Dungeons & Dragons. Most of these games cast the player in the role of one or more 'adventurers' who specialize in specific skill sets (such as melee combat or casting magic spells) while progressing through a predetermined storyline. Many involve manoeuvring these character(s) through an overworld, usually populated with monsters, that allows access to more important game locations, such as towns, dungeons, and castles. Since the emergence of affordable home computers coincided with the popularity of paper and pencil role-playing games, this genre was one of the first in video games and continues to be popular today. Gameplay elements strongly associated with RPG, such as statistical character development through the acquisition of experience points, have been widely adapted to other genres such as action-adventure games. Though nearly all of the early entries in the genre were turn-based games, many modern role-playing games progress in real-time. Thus, the genre has followed the strategy game's trend of moving from turn-based to real-time combat. The move to real-time combat began with the release of Square's (now Square Enix's) Final Fantasy IV, the first game to use the Active Time Battle system; this was quickly followed by truly real-time role-playing games such as the Mana series, Soul Blazer and Ultima VII. Some throwbacks to older turn-based system did exist such as the Golden Sun series for Game Boy Advance."},
                new Categorias {ID=7, Nome="Sports", Descricao="Sports are video games that simulate sports. This opposing team(s) can be controlled by other real life people or artificial intelligence."},
                new Categorias {ID=8, Nome="Singleplayer", Descricao="Games that can only be played by 1 person and dont have online or local multiplayer features"},
                new Categorias {ID=9, Nome="Multiplayer", Descricao="Games that can be played by multiple people online or locally"},
                new Categorias {ID=10, Nome="Puzzle", Descricao="Puzzle games require the player to solve logic puzzles or navigate complex locations such as mazes. They are well suited to casual play, and tile-matching puzzle games are among the most popular casual games. This genre frequently crosses over with adventure and educational games. Tetris, labeled a puzzle game, is credited for revolutionizing gaming and popularizing the puzzle genre."}
            };
            categorias.ForEach(aa => context.Categoria.AddOrUpdate(a => a.Nome, aa));
            context.SaveChanges();

            var jogos = new List<Jogos> {
                new Jogos {ID=1, Nome="Dark Souls : Remastered", Preco=39.99, Capa="darkSoulsRemastered.jpg", Descricao="Then, there was fire. Re-experience the critically acclaimed, genre-defining game that started it all. Beautifully remastered, return to Lordran in stunning high-definition detail running at 60fps. Dark Souls Remastered includes the main game plus the Artorias of the Abyss DLC.", ListaDeCategorias= new List<Categorias>{categorias[0], categorias[5]}},
                new Jogos {ID=2, Nome="Counter-Strike: Global Offensive", Preco=12.49, Capa="counterStrikeGO.jpg", Descricao="Counter-Strike: Global Offensive (CS: GO) will expand upon the team-based action gameplay that it pioneered when it was launched 14 years ago. CS: GO features new maps, characters, and weapons and delivers updated versions of the classic CS content (de_dust2, etc.). In addition, CS: GO will introduce new gameplay modes, matchmaking, leader boards, and more.", ListaDeCategorias= new List<Categorias>{categorias[0], categorias[1]}},
                new Jogos {ID=3, Nome="Bioshock Infinite", Preco=29.99, Capa="bioshockInfinite.jpg", Descricao="Indebted to the wrong people, with his life on the line, veteran of the U.S. Cavalry and now hired gun, Booker DeWitt has only one opportunity to wipe his slate clean. He must rescue Elizabeth, a mysterious girl imprisoned since childhood and locked up in the flying city of Columbia. Forced to trust one another, Booker and Elizabeth form a powerful bond during their daring escape. Together, they learn to harness an expanding arsenal of weapons and abilities, as they fight on zeppelins in the clouds, along high-speed Sky-Lines, and down in the streets of Columbia, all while surviving the threats of the air-city and uncovering its dark secret.", ListaDeCategorias= new List<Categorias>{categorias[0], categorias[1], categorias[3]}},
                new Jogos {ID=4, Nome="Borderlands 2", Preco=29.99, Capa="borderlands2.jpg", Descricao="A new era of shoot and loot is about to begin. Play as one of four new vault hunters facing off against a massive new world of creatures, psychos and the evil mastermind, Handsome Jack. Make new friends, arm them with a bazillion weapons and fight alongside them in 4 player co-op on a relentless quest for revenge and redemption across the undiscovered and unpredictable living planet.", ListaDeCategorias= new List<Categorias>{categorias[0], categorias[1]}},
                new Jogos {ID=5, Nome="Rocket League", Preco= 19.99, Capa="rocketLeague.jpg", Descricao="Soccer meets driving once again in the long-awaited, physics-based sequel to the beloved arena classic, Supersonic Acrobatic Rocket-Powered Battle-Cars! A futuristic Sports-Action game, Rocket League®, equips players with booster-rigged vehicles that can be crashed into balls for incredible goals or epic saves across multiple, highly-detailed arenas. Using an advanced physics system to simulate realistic interactions, Rocket League® relies on mass and momentum to give players a complete sense of intuitive control in this unbelievable, high-octane re-imagining of association football.", ListaDeCategorias= new List<Categorias>{categorias[8], categorias[4], categorias[6]}},
                new Jogos {ID=6, Nome="Fallout 4", Preco= 29.99, Capa="fallout4.jpg", Descricao="Bethesda Game Studios, the award-winning creators of Fallout 3 and The Elder Scrolls V: Skyrim, welcome you to the world of Fallout 4 – their most ambitious game ever, and the next generation of open-world gaming. As the sole survivor of Vault 111, you enter a world destroyed by nuclear war. Every second is a fight for survival, and every choice is yours. Only you can rebuild and determine the fate of the Wasteland. Welcome home.", ListaDeCategorias= new List<Categorias>{categorias[0], categorias[5]}},
                new Jogos {ID=7, Nome="The Witcher 3", Preco= 29.99, Capa="witcher3.jpg", Descricao="The Witcher: Wild Hunt is a story-driven, next-generation open world role-playing game set in a visually stunning fantasy universe full of meaningful choices and impactful consequences. In The Witcher you play as the professional monster hunter, Geralt of Rivia, tasked with finding a child of prophecy in a vast open world rich with merchant cities, viking pirate islands, dangerous mountain passes, and forgotten caverns to explore.", ListaDeCategorias= new List<Categorias>{categorias[0], categorias[1], categorias[5]}},
                new Jogos {ID=8, Nome="Payday 2", Preco= 9.99, Capa="payday2.jpg", Descricao="PAYDAY 2 is an action-packed, four-player co-op shooter that once again lets gamers don the masks of the original PAYDAY crew - Dallas, Hoxton, Wolf and Chains - as they descend on Washington DC for an epic crime spree. The new CRIMENET network offers a huge range of dynamic contracts, and players are free to choose anything from small-time convenience store hits or kidnappings, to big league cyber-crime or emptying out major bank vaults for that epic PAYDAY. While in DC, why not participate in the local community, and run a few political errands? Up to four friends co-operate on the hits, and as the crew progresses the jobs become bigger, better and more rewarding. Along with earning more money and becoming a legendary criminal comes a new character customization and crafting system that lets crews build and customize their own guns and gear.", ListaDeCategorias= new List<Categorias>{categorias[0], categorias[2], categorias[8], categorias[9]}},
                new Jogos {ID=9, Nome="Cuphead", Preco= 19.99, Capa="cuphead.jpg", Descricao="Cuphead is a classic run and gun action game heavily focused on boss battles. Inspired by cartoons of the 1930s, the visuals and audio are painstakingly created with the same techniques of the era, i.e. traditional hand drawn cel animation, watercolor backgrounds, and original jazz recordings. Play as Cuphead or Mugman (in single player or local co-op) as you traverse strange worlds, acquire new weapons, learn powerful super moves, and discover hidden secrets while you try to pay your debt back to the devil!", ListaDeCategorias= new List<Categorias>{categorias[0], categorias[1], categorias[2]}}
            };
            jogos.ForEach(aa => context.Jogos.AddOrUpdate(a => a.Nome, aa));
            context.SaveChanges();

            var media = new List<Media> {
                new Media {ID=1, Fotografia="darkSoulsRemastered1.jpg", tipo="img", JogosFK=1},
                new Media {ID=2, Fotografia="darkSoulsRemastered2.jpg", tipo="img", JogosFK=1},
                new Media {ID=3, Fotografia="darkSoulsRemastered3.jpg", tipo="img", JogosFK=1},
                new Media {ID=4, Fotografia="darkSoulsRemastered4.jpg", tipo="img", JogosFK=1},
                new Media {ID=5, Fotografia="counterStrikeGO1.jpg", tipo="img", JogosFK=2},
                new Media {ID=6, Fotografia="counterStrikeGO2.jpg", tipo="img", JogosFK=2},
                new Media {ID=7, Fotografia="counterStrikeGO3.jpg", tipo="img", JogosFK=2},
                new Media {ID=8, Fotografia="counterStrikeGO4.jpg", tipo="img", JogosFK=2},
                new Media {ID=9, Fotografia="bioshockInfinite1.jpg", tipo="img", JogosFK=3},
                new Media {ID=10, Fotografia="bioshockInfinite2.jpg", tipo="img", JogosFK=3},
                new Media {ID=11, Fotografia="bioshockInfinite3.jpg", tipo="img", JogosFK=3},
                new Media {ID=12, Fotografia="bioshockInfinite4.jpg", tipo="img", JogosFK=3},
                new Media {ID=13, Fotografia="borderlands21.jpg", tipo="img", JogosFK=4},
                new Media {ID=14, Fotografia="borderlands22.jpg", tipo="img", JogosFK=4},
                new Media {ID=15, Fotografia="borderlands23.jpg", tipo="img", JogosFK=4},
                new Media {ID=16, Fotografia="borderlands24.jpg", tipo="img", JogosFK=4},
                new Media {ID=17, Fotografia="rocketLeague1.jpg", tipo="img", JogosFK=5},
                new Media {ID=18, Fotografia="rocketLeague2.jpg", tipo="img", JogosFK=5},
                new Media {ID=19, Fotografia="rocketLeague3.jpg", tipo="img", JogosFK=5},
                new Media {ID=20, Fotografia="rocketLeague4.jpg", tipo="img", JogosFK=5},
                new Media {ID=21, Fotografia="fallout41.jpg", tipo="img", JogosFK=6},
                new Media {ID=22, Fotografia="fallout42.jpg", tipo="img", JogosFK=6},
                new Media {ID=23, Fotografia="fallout43.jpg", tipo="img", JogosFK=6},
                new Media {ID=24, Fotografia="fallout44.jpg", tipo="img", JogosFK=6},
                new Media {ID=25, Fotografia="witcher31.jpg", tipo="img", JogosFK=7},
                new Media {ID=26, Fotografia="witcher32.jpg", tipo="img", JogosFK=7},
                new Media {ID=27, Fotografia="witcher33.jpg", tipo="img", JogosFK=7},
                new Media {ID=28, Fotografia="witcher34.jpg", tipo="img", JogosFK=7},
                new Media {ID=29, Fotografia="payday21.jpg", tipo="img", JogosFK=8},
                new Media {ID=30, Fotografia="payday22.jpg", tipo="img", JogosFK=8},
                new Media {ID=31, Fotografia="payday23.jpg", tipo="img", JogosFK=8},
                new Media {ID=32, Fotografia="payday24.jpg", tipo="img", JogosFK=8},
                new Media {ID=33, Fotografia="cuphead1.jpg", tipo="img", JogosFK=9},
                new Media {ID=34, Fotografia="cuphead2.jpg", tipo="img", JogosFK=9},
                new Media {ID=35, Fotografia="cuphead3.jpg", tipo="img", JogosFK=9},
                new Media {ID=36, Fotografia="cuphead4.jpg", tipo="img", JogosFK=9}

            };
            media.ForEach(aa => context.Media.AddOrUpdate(a => a.Fotografia, aa));
            context.SaveChanges();

            var clientes = new List<Cliente> {
                new Cliente {ID=1, Nome = "Luis Exemplo", Email="mail1@mail.pt", DataNascimento = new DateTime(1999, 1, 4)},
                new Cliente {ID=2, Nome = "Joao Teste", Email="mail2@mail.pt", DataNascimento = new DateTime(1984, 7, 9)},
                new Cliente {ID=3, Nome = "Maria Trabalho", Email="mail3@mail.pt", DataNascimento = new DateTime(1990, 8, 5)},
                new Cliente {ID=4, Nome = "Andre Fronteira", Email="mail4@mail.pt", DataNascimento = new DateTime(1976, 8, 8)},
                new Cliente {ID=5, Nome = "Miguel Antonio", Email="mail5@mail.pt", DataNascimento = new DateTime(1998, 12, 11)},
            };
            clientes.ForEach(aa => context.Cliente.AddOrUpdate(a => a.Nome, aa));
            context.SaveChanges();
        }
    }
}
