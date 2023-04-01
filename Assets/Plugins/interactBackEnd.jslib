mergeInto(LibraryManager.library, {

  ReadyStatusCheck: function (address) {
    const auth = fetch(`https://catapult-backend.herokuapp.com/user/status/` + address);
    const status = auth.json();
    console.log(status);
    console.log(status.user_playing);
    return status.user_playing;
  },

  GetAmount: function(address) {
    const data = fetch(`https://catapult-backend.herokuapp.com/user/nft/` + address);
    return data.json();
  },

  PlayDone: function(address) {
    const body = { 
        user_playing: false
      }
    const response = fetch(`https://catapult-backend.herokuapp.com/user/finish/${address}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(body)
      });
  },


});