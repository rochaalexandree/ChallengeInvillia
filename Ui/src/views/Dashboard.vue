<template>
  <div>
    <Nav />
    <div class="container-fluid">
      <div class="row">
        <div class="col-md-4">
          <ul class="list-group">
            <li class="list-group-item active">
              GAMES
            </li>
            <li v-for="g in storagedGames" :key="g" class="list-group-item list-game-item">
              <div>
                {{ g.Name }}
              </div>
              <select v-model="selectedValues[g]" class="form-control" style="width: 100px; margin: 8px 8px 8px auto">
                <option v-for="friend in friends" :key="friend.Name">{{friend.Name}}</option>
              </select>
              <button class="btn btn-light" @click="() => handleEmprestar(g)"> Emprestar </button>
            </li>
          </ul>
        </div>
        <div class="col-md-8">
          <div class="row">
            <div v-for="item in friends" :key="item.Name" class="col-md-4">
              <div class="card" style="margin: 0px 0 32px">
                <div class="card-body">
                  <h5 class="card-title">{{ item.Name }}</h5>
                  <p class="card-text">{{ item.Email }}</p>
                  <ul class="list-group">
                    <li v-show="item.Games" class="list-group-item active">
                      GAMES
                    </li>
                    <li class="list-group-item" v-for="game in item.Games" :key="game">
                      {{ game.Name }}
                    </li>
                  </ul>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import http from '../utils/http';
import Nav from '@/components/Nav';
import { LOGOUT } from '@/store/actions.type.js';

export default {
  name: 'Dashboard',
  components: {
    Nav,
  },
  data: function() {
    return {
      name: this.$store.state.auth.userName,
      friends: [
        // { Name: 'XX 1', Age: 10, email: 'abc@hotmail.com', Games: [
        //   { Name: "adsdas", type: "action", isOnLoan: true },
        //   { Name: "here", type: "action", isOnLoan: false }
        // ]},
        // { Name: 'YY laksdk', Age: 10, email: 'abc@hotmail.com', Games: [
        //   { Name: "KKK", type: "action", isOnLoan: true },
        //   { Name: "xD", type: "action", isOnLoan: false }
        // ]},
      ],
      storagedGames: [
        // { Name: "assasins creed", type: "action", isOnLoan: false },
        // { Name: "wingin eleven", type: "action", isOnLoan: false },
        // { Name: "um nome muito grande para caber em uma linha", type: "action", isOnLoan: false }
      ],
      selectedValues: {}
    }
  },
  methods: {
    logout: function() {
      this.$store
        .dispatch(LOGOUT)
        .then(() => {
          this.$router.push({ path: '/' })
        })
        .catch(() => {});
    },
    handleEmprestar: function(game) {
      if (!game || !this.selectedValues[game] ) {
        return;
      }
      console.log(game, this.selectedValues[game]);

    }
  },
  created: function() {
    http.get(`api/friends`, { headers: { "Authorization":`Bearer ${this.$store.state.auth.token}`} })
    .then((response) => {
      this.friends = response.data;
    })
    .catch(function () {});
    
     http.get(`api/games`, { headers: { "Authorization":`Bearer ${this.$store.state.auth.token}`} })
    .then((response) => {
      this.storagedGames = response.data;
    })
    .catch(function () {});
  },
}
</script>


<style>
.list-game-item {
  display: flex;
  justify-content: space-between;
  align-items: center;
  flex-direction: row;
}
</style>