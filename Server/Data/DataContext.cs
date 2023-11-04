using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BlazorEcommerce.Server.Data;

public class DataContext : DbContext
{
	public DataContext(DbContextOptions<DataContext> options) : base(options) { }

	public DbSet<Product> Products { get; set; }
	public DbSet<Category> Categories { get; set; }
	public DbSet<ProductVariant> ProductVariants { get; set; }
	public DbSet<ProductType> ProductTypes { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// set primary key for table
		modelBuilder.Entity<ProductVariant>().HasKey(x => new { x.ProductId, x.ProductTypeId });
		modelBuilder.Entity<ProductType>().HasData(
					new() { Id = 1, Name = "Default" },
					new() { Id = 2, Name = "Paperback" },
					new() { Id = 3, Name = "E-Book" },
					new() { Id = 4, Name = "Audiobook" },
					new() { Id = 5, Name = "Stream" },
					new() { Id = 6, Name = "Blu-ray" },
					new() { Id = 7, Name = "VHS" },
					new() { Id = 8, Name = "PC" },
					new() { Id = 9, Name = "PlayStation" },
					new() { Id = 10, Name = "Xbox" }
				);
		modelBuilder.Entity<Category>().HasData(new Category[]
		{
			new()
			{
				Id = 1,
				Name = "Movies",
				Url = "movies"
			},
			new()
			{
				Id = 2,
				Name = "Books",
				Url = "books"
			},
			new()
			{
				Id  =3,
				Name = "VideoGames",
				Url = "video-games"
			}
		});
		modelBuilder.Entity<Product>().HasData(new Product[]
		{
			new()
			{
				Id=1,
				Title = "The Philadelphia Story",
				ImageUrl = "https://img2.doubanio.com/view/photo/l/public/p740274403.webp",
				Description = "The Philadelphia Story is a 1940 American romantic comedy film directed by George Cukor, starring Cary Grant, Katharine Hepburn, James Stewart, and Ruth Hussey. Based on the 1939 Broadway play of the same name by Philip Barry,[4] the film is about a socialite whose wedding plans are complicated by the simultaneous arrival of her ex-husband and a tabloid magazine journalist. The socialite character of the play—performed by Hepburn in the film—was inspired by Helen Hope Montgomery Scott (1904–1995), a Philadelphia socialite known for her hijinks, who married a friend of playwright Barry.",
				CategoryId = 1
			},
			new()
			{
				Id=2,
				Title = "Seven Samurai",
				ImageUrl = "https://alternativemovieposters.com/wp-content/uploads/2015/08/sevensamurai.jpg",
				Description = "Seven Samurai (Japanese: 七人の侍, Hepburn: Shichinin no Samurai) is a 1954 Japanese epic samurai film co-written, edited, and directed by Akira Kurosawa. Taking place in 1586[a] in the Sengoku period of Japanese history, it follows the story of a village of desperate farmers who seek to hire rōnin (masterless samurai) to combat bandits who will return after the harvest to steal their crops.\r\n\r\nAt the time, the film was the most expensive film made in Japan. It took a year to shoot and faced many difficulties. It was the second-highest-grossing domestic film in Japan in 1954. Many reviews compared the film to westerns.",
				CategoryId = 1,
				IsFeatured =  true
			},
			new()
			{
				Id=3,
				Title = "Singin' in the Rain",
				ImageUrl = "http://www.suzannestengl.com/wp-content/uploads/2014/08/2014-08-19-Singin-in-the-Rain-Movie-Poster-courtesy-MGM.jpg",
				Description = "Singin' in the Rain is a 1952 American musical romantic comedy film directed and choreographed by Gene Kelly and Stanley Donen, starring Kelly, Donald O'Connor, and Debbie Reynolds and featuring Jean Hagen, Millard Mitchell and Cyd Charisse. It offers a lighthearted depiction of Hollywood in the late 1920s, with the three stars portraying performers caught up in the transition from silent films to \"talkies\".",
				CategoryId = 1,
				IsFeatured =  true
			},
			new()
			{
				Id=4,
				Title = "Throne of Blood",
				ImageUrl = "https://img2.doubanio.com/view/photo/l/public/p2640721072.webp",
				Description = "Throne of Blood (Japanese: 蜘蛛巣城, Hepburn: Kumonosu-jō, lit. 'The Castle of Spider's Web') is a 1957 Japanese jidaigeki film co-written, produced, edited, and directed by Akira Kurosawa, with special effects by Eiji Tsuburaya. The film transposes the plot of William Shakespeare's play Macbeth from Medieval Scotland to feudal Japan, with stylistic elements drawn from Noh drama. The film stars Toshiro Mifune and Isuzu Yamada in the lead roles, modelled on the characters Macbeth and Lady Macbeth.\r\n\r\nAs with the play, the film tells the story of a warrior who assassinates his sovereign at the urging of his ambitious wife. Kurosawa was a fan of the play and intended to make his own adaptation for several years, delaying it after learning of Orson Welles' Macbeth (1948). Among his changes was the ending, which required archers to fire arrows around Mifune. The film was shot around Mount Fuji and Izu Peninsula.",
				CategoryId = 1,
				IsFeatured =  true
			},
			new()
			{
				Id = 5,
				Title  ="2001: A Space Odyssey",
				ImageUrl = "https://posterspy.com/wp-content/uploads/2018/06/Poster-2001-A-Space-Odyssey-Commercial-II.jpg",
				Description = "2001: A Space Odyssey is a 1968 epic science fiction film produced and directed by Stanley Kubrick. The screenplay was written by Kubrick and science fiction author Arthur C. Clarke, and was inspired by Clarke's 1951 short story \"The Sentinel\" and other short stories by Clarke. Clarke also published a novelisation of the film, in part written concurrently with the screenplay, after the film's release. The film stars Keir Dullea, Gary Lockwood, William Sylvester, and Douglas Rain and follows a voyage by astronauts, scientists, and the sentient supercomputer HAL to Jupiter to investigate an alien monolith.\r\n\r\nThe film is noted for its scientifically accurate depiction of space flight, pioneering special effects, and ambiguous imagery. Kubrick avoided conventional cinematic and narrative techniques; dialogue is used sparingly, and there are long sequences accompanied only by music. The soundtrack incorporates numerous works of classical music, including pieces by composers such as Richard Strauss, Johann Strauss II, Aram Khachaturian, and György Ligeti.",
				CategoryId = 1
			},
			new()
			{
				Id = 6,
				Title = "The Hitchhiker's Guide to the Galaxy",
				Description = "The Hitchhiker's Guide to the Galaxy[note 1] (sometimes referred to as HG2G,[1] HHGTTG,[2] H2G2,[3] or tHGttG) is a comedy science fiction franchise created by Douglas Adams. Originally a 1978 radio comedy broadcast on BBC Radio 4, it was later adapted to other formats, including stage shows, novels, comic books, a 1981 TV series, a 1984 text-based computer game, and 2005 feature film.",
				ImageUrl = "https://images.wolfgangsvault.com/m/xlarge/ZZZ061776-PO/the-hitchhikers-guide-to-the-galaxy-poster-apr-29-2005.jpg",
				CategoryId = 1
			},
			new()
			{
				Id = 7,
				Title = "Ready Player One",
				Description = "Ready Player One is a 2011 science fiction novel, and the debut novel of American author Ernest Cline. The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune. Cline sold the rights to publish the novel in June 2010, in a bidding war to the Crown Publishing Group (a division of Random House).[1] The book was published on August 16, 2011.[2] An audiobook was released the same day; it was narrated by Wil Wheaton, who was mentioned briefly in one of the chapters.[3][4]Ch. 20 In 2012, the book received an Alex Award from the Young Adult Library Services Association division of the American Library Association[5] and won the 2011 Prometheus Award.[6]",
				ImageUrl = "https://cdn.traileraddict.com/content/warner-bros-pictures/ready-player-one-poster-9.jpg",
				CategoryId = 1
			},
			new()
			{
				Id = 8,
				Title = "Nineteen Eighty-Four",
				Description = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated.",
				ImageUrl = "https://c8.alamy.com/comp/B7TYYD/nineteen-eighty-four-year-1984-uk-affiche-poster-director-michael-B7TYYD.jpg",
				CategoryId = 1
			},
			new()
			{
				Id = 9,
				CategoryId = 2,
				Title = "The Matrix",
				Description = "The Matrix is a 1999 science fiction action film written and directed by the Wachowskis, and produced by Joel Silver. Starring Keanu Reeves, Laurence Fishburne, Carrie-Anne Moss, Hugo Weaving, and Joe Pantoliano, and as the first installment in the Matrix franchise, it depicts a dystopian future in which humanity is unknowingly trapped inside a simulated reality, the Matrix, which intelligent machines have created to distract humans while using their bodies as an energy source. When computer programmer Thomas Anderson, under the hacker alias \"Neo\", uncovers the truth, he \"is drawn into a rebellion against the machines\" along with other people who have been freed from the Matrix.",
				ImageUrl = "https://image.tmdb.org/t/p/original/dXNAPwY7VrqMAo51EKhhCJfaGb5.jpg",
			},
			new()
			{
				Id = 10,
				CategoryId = 2,
				Title = "Back to the Future",
				Description = "Back to the Future is a 1985 American science fiction film directed by Robert Zemeckis. Written by Zemeckis and Bob Gale, it stars Michael J. Fox, Christopher Lloyd, Lea Thompson, Crispin Glover, and Thomas F. Wilson. Set in 1985, the story follows Marty McFly (Fox), a teenager accidentally sent back to 1955 in a time-traveling DeLorean automobile built by his eccentric scientist friend Doctor Emmett \"Doc\" Brown (Lloyd). Trapped in the past, Marty inadvertently prevents his future parents' meeting—threatening his very existence—and is forced to reconcile the pair and somehow get back to the future.",
				ImageUrl = "http://images5.fanpop.com/image/polls/1042000/1042136_1338502936438_full.jpg",
			},
			new()
			{
				Id = 11,
				CategoryId = 2,
				Title = "Toy Story",
				Description = "Toy Story is a 1995 American computer-animated comedy film produced by Pixar Animation Studios and released by Walt Disney Pictures. The first installment in the Toy Story franchise, it was the first entirely computer-animated feature film, as well as the first feature film from Pixar. The film was directed by John Lasseter (in his feature directorial debut), and written by Joss Whedon, Andrew Stanton, Joel Cohen, and Alec Sokolow from a story by Lasseter, Stanton, Pete Docter, and Joe Ranft. The film features music by Randy Newman, was produced by Bonnie Arnold and Ralph Guggenheim, and was executive-produced by Steve Jobs and Edwin Catmull. The film features the voices of Tom Hanks, Tim Allen, Don Rickles, Wallace Shawn, John Ratzenberger, Jim Varney, Annie Potts, R. Lee Ermey, John Morris, Laurie Metcalf, and Erik von Detten. Taking place in a world where anthropomorphic toys come to life when humans are not present, the plot focuses on the relationship between an old-fashioned pull-string cowboy doll named Woody and an astronaut action figure, Buzz Lightyear, as they evolve from rivals competing for the affections of their owner, Andy Davis, to friends who work together to be reunited with Andy after being separated from him.",
				ImageUrl = "https://originalvintagemovieposters.com/wp-content/uploads/2020/02/TOY-STORY-8479-scaled.jpg",
			},
			new()
			{
				Id = 12,
				CategoryId = 3,
				Title = "Half-Life 2",
				Description = "Half-Life 2 is a 2004 first-person shooter game developed and published by Valve. Like the original Half-Life, it combines shooting, puzzles, and storytelling, and adds features such as vehicles and physics-based gameplay.",
				ImageUrl = "https://media.senscritique.com/media/000019102812/source_big/Half_Life_2.jpg",
			},
			new()
			{
				Id = 13,
				CategoryId = 3,
				Title = "Diablo II",
				Description = "Diablo II is an action role-playing hack-and-slash computer video game developed by Blizzard North and published by Blizzard Entertainment in 2000 for Microsoft Windows, Classic Mac OS, and macOS.",
				ImageUrl = "https://macgamesland.com/uploads/posts/2020-02/1582762379_poster-diablo-1.jpg",
			},
			new()
			{
				Id = 14,
				CategoryId = 3,
				Title = "Day of the Tentacle",
				Description = "Day of the Tentacle, also known as Maniac Mansion II: Day of the Tentacle, is a 1993 graphic adventure game developed and published by LucasArts. It is the sequel to the 1987 game Maniac Mansion.",
				ImageUrl = "http://images6.fanpop.com/image/photos/36800000/Day-of-the-Tentacle-Poster-day-of-the-tentacle-36836832-467-702.png",
			},
			new()
			{
				Id = 15,
				CategoryId = 3,
				Title = "Xbox",
				Description = "The Xbox is a home video game console and the first installment in the Xbox series of video game consoles manufactured by Microsoft.",
				ImageUrl = "https://posterspy.com/wp-content/uploads/2014/08/Poaster.png",
			},
			new()
			{
				Id = 16,
				CategoryId = 3,
				Title = "Super Nintendo Entertainment System",
				Description = "The Super Nintendo Entertainment System (SNES), also known as the Super NES or Super Nintendo, is a 16-bit home video game console developed by Nintendo that was released in 1990 in Japan and South Korea.",
				ImageUrl = "https://wallsdesk.com/wp-content/uploads/2016/10/Nintendo-Switch-logo.jpg",
			}
		});
		modelBuilder.Entity<ProductVariant>().HasData(new ProductVariant[]
		{
				new()
				{
					ProductId = 1,
					ProductTypeId = 2,
					Price = 9.99m,
					OriginalPrice = 19.99m
				},
				new()
				{
					ProductId = 1,
					ProductTypeId = 3,
					Price = 7.99m
				},
				new()
				{
					ProductId = 1,
					ProductTypeId = 4,
					Price = 19.99m,
					OriginalPrice = 29.99m
				},
				new()
				{
					ProductId = 2,
					ProductTypeId = 2,
					Price = 7.99m,
					OriginalPrice = 14.99m
				},
				new()
				{
					ProductId = 3,
					ProductTypeId = 2,
					Price = 6.99m
				},
				new()
				{
					ProductId = 4,
					ProductTypeId = 5,
					Price = 3.99m
				},
				new()
				{
					ProductId = 4,
					ProductTypeId = 6,
					Price = 9.99m
				},
				new()
				{
					ProductId = 4,
					ProductTypeId = 7,
					Price = 19.99m
				},
				new()
				{
					ProductId = 5,
					ProductTypeId = 5,
					Price = 3.99m,
				},
				new()
				{
					ProductId = 6,
					ProductTypeId = 5,
					Price = 2.99m
				},
				new()
				{
					ProductId = 7,
					ProductTypeId = 8,
					Price = 19.99m,
					OriginalPrice = 29.99m
				},
				new()
				{
					ProductId = 7,
					ProductTypeId = 9,
					Price = 69.99m
				},
				new()
				{
					ProductId = 7,
					ProductTypeId = 10,
					Price = 49.99m,
					OriginalPrice = 59.99m
				},
				new()
				{
					ProductId = 8,
					ProductTypeId = 8,
					Price = 9.99m,
					OriginalPrice = 24.99m,
				},
				new()
				{
					ProductId = 9,
					ProductTypeId = 8,
					Price = 14.99m
				},
				new()
				{
					ProductId = 10,
					ProductTypeId = 1,
					Price = 159.99m,
					OriginalPrice = 299m
				},
				new()
				{
					ProductId = 11,
					ProductTypeId = 1,
					Price = 79.99m,
					OriginalPrice = 399m
				}
			}
		);
	}
	private static decimal RandomPrice()
	{
		var min = 10.81;
		var max = 102.49;
		var centCount = (int)(max - min) * 100;
		return (decimal)(min + (Random.Shared.Next(centCount) * 0.01));
	}
}