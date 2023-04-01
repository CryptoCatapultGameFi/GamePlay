mergeInto(LibraryManager.library, {

  Close: function () {
    window.location.href = "https://cryptocatapult.herokuapp.com/";
    window.close();
  },

  Close5Seconds: function () {
    setTimeout(function() {
      window.close();
    }, 5000);
  },
});