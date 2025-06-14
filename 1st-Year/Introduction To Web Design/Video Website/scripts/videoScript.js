document.addEventListener ('DOMContentLoaded', intialiseWebPage);

function intialiseWebPage()
{
	const myVideo = document.querySelector ( "video" ); //Listens for the HTML ID to connect to the JavaSxript code
	const playButton = document.getElementById ("playPause");
	const muteButton = document.getElementById ("muteUnmute");
	const scrubSlider = document.getElementById ("seekBar");
	const volumeSlider = document.getElementById ("volumeBar");
	const currentTimeField = document.getElementById ("currentTimeField");
	const remainingTimeField = document.getElementById ("remainingTimeField");
	const playBackRate = document.getElementById ("playBackRate"); 
	const volumeNumber = document.getElementById ("volumeBarNumber");


	playButton.addEventListener( "click", playPauseVideo ) ; //Listen's for user to click on the button
	muteButton.addEventListener( "click", muteUnmute ) ;

	playBackRate.addEventListener ("input", playBackRateSpeed) ; //Listen's for user to put an input in 
	scrubSlider.addEventListener ("input", scrubVideo) ;
	volumeSlider.addEventListener ("input", scrubAudio) ;
	volumeBarNumber.addEventListener ("input", volumeBarNumberDisplay) ;
	
	myVideo.addEventListener ("timeupdate", displayCurrentTime) ; //Listen's for the time of myVideo
	myVideo.addEventListener ("timeupdate", displayRemainingTime) ;

	document.addEventListener ("visibilitychange", changeTab) ; //Listen's for the video to not be visible
	document.addEventListener("keydown", shortcutKeys); //Listen's for a keypress
	
//Key Binds

	function shortcutKeys(event)
	{
		switch(event.key) //Increases Video Volume
		{
			case "ArrowUp":
			case "w":
			case "W":
				if(myVideo.volume < 1)
				{
					myVideo.volume += 0.1;
					volumeSlider.value = myVideo.volume + 0.1;
					scrubAudio.value = volumeSlider.value;
				}
				else
				{
					myVideo.volume = 1;
					volumeSlider.value = myVideo.value + 0.1;
					scrubAudio.value = volumeSlider.value;
				}
				break;
		}
		switch(event.key) //Decreases Video Volume
		{
			case "ArrowDown":
			case "s":
			case "S":
				if(myVideo.volume > 1)
				{
					myVideo.volume -= 0.1;
					volumeSlider.value = myVideo.volume - 0.1;
					scrubAudio.value = volumeSlider.value;
				}
				else
				{
					myVideo.volume = 1;
					volumeSlider.value = myVideo.value - 0.1;
					scrubAudio.value = volumeSlider.value;
				}
				break;
		}
		switch(event.key) //Pauses Video
		{
			case "p":
			case "P":
			playPauseVideo();
			break;
		}
		switch(event.key) //Mutes Video
		{
			case "m":
			case "m":
			muteUnmute();
			break;
		}
		switch(event.key) //Video Rewind
		{
			case "ArrowLeft":
			case "a":
			case "A":
				scrubVideo() % 100;
				break;
		}
		switch(event.key) //Video Fast-Foward
		{
			case "ArrowRight":
			case "d":
			case "D":
				 scrubVideo() * 100;
				break;
		}
	}

//functions

	function playPauseVideo() //Play-Pause Button Function
	{
		if (myVideo.paused === true)
		{
			myVideo.play();
			playButton.innerHTML = "Pause";
		}
		else
		{
			myVideo.pause();
			playButton.innerHTML = "Play";
		}
	}
	
	function muteUnmute() //Mute - unmute button Function
	{
		if (myVideo.muted === true)
		{
			myVideo.muted = false;
			muteButton.innerHTML = "Mute";
			scrubAudio() = 0;
		}
		else
		{
			myVideo.muted = true;
			muteButton.innerHTML = "UnMute";
		}
	}
	
	function scrubVideo() 
	{
		const scrubTime = myVideo.duration * (scrubSlider.value /100) ;
		myVideo.currentTime = scrubTime ;
	}
	
	myVideo.addEventListener ( "timeupdate", movePlaySlider ) ;
	 
	function movePlaySlider() //Listener for ScribVideo to move the video slider Function
	{
		scrubSlider.value = (myVideo.currentTime/myVideo.duration )* 100 ;
	}

	function scrubAudio() //Audio Scrib Slider Function
	{
		myVideo.volume = 0;
		const volumeScrub = myVideo.volume = volumeSlider.value;
		myVideo.volume = volumeScrub;
		if (myVideo.volume === 0)
		{
			muteButton.innerHTML = "UnMute"

		}
		else
		{
			muteButton.innerHTML = "Mute"
		}	
	}

	function volumeBarNumberDisplay() //Number next to volume Bar Function
	{
		myVideo.volume = 0;
		const volumeScrub = myVideo.volume = volumeSlider.value;
		const volumeNumberValue = volumeSlider.value = volumeNumber.value;
		volumeScrub.value = volumeBar.value;
	}
	
	function displayCurrentTime() //Current time in video Function
	{
		const timeDisplay = myVideo.currentTime;
		const minutes = Math.floor(myVideo.currentTime / 60);
		const seconds = Math.floor(myVideo.currentTime % 60);
		currentTimeField.value = minutes+":"+seconds;
	}	
	
	function displayRemainingTime() //remaining time of video Function
	{
		const remainingTimeDisplay = myVideo.duration - myVideo.currentTime;
		const minutes = Math.floor(myVideo.duration - myVideo.currentTime) / 60 ;
		const seconds = Math.floor(myVideo.duration - myVideo.currentTime) % 60 ;
		remainingTimeField.value = minutes+":"+seconds;
	}

	function playBackRateSpeed() //playback rate Function
	{
		myVideo.playbackRate = playBackRate.value;
	}

	function changeTab() //change tab Function
	{
		if(myVideo.pause())
		{
			myVideo.play();
			playButton.innerHTML = "Pause";
		}
		if(myVideo.play())
		{
			myVideo.pause();
			playButton.innerHTML = "Play";
		}
	}
}
