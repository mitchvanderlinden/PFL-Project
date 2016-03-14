# PFL-Project
The PFL evaluation web project

This allows the user to select from a list of available products, fill out the necessary
shipping information, and place an order, whereby a confirmation number is displayed.

Notes:

Some things that I was unable to implement due to time restrictions:
- Support for adding multiple items to a single order
- User input error handling (ex: quantity is not an integer, email not valid, etc.)
- Order status checking (I used the example console app to ensure orders were submitting)
- Support for every option when ordering (I only implemented what was necessary)
- Prevent postback for every page action while still updating the view
- Major code refactoring: It's a mess

As I mentioned during our meeting, this is really the first time I've done any fron end web
development, so there was definitely a learning curve. I decided to use ASP.NET since I'm
comfortable with C#. It took a good deal of time to grasp the page asp.net lifecycle, and
this led to some wasted time getting eventhandling working properly. This unforetunately limited
the amount of functionality I was hoping to achieved. As I had not previously worked with JSON
or HTTP requests, this also took some time to learn - I found the console example helpful.

I love learning new skills, so although it took a while to learn some of the necessary protocols,
I had fun working on this. Were I asked to complete a similar project again, I believe I could now
produce a hgiher-quality product in much less time.