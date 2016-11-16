var data = [
  { id: 1, description: "This is one todo" },
  { id: 2, description: "This is *another* todo" }
];

var ToDoItem = React.createClass({
    handleCheck: function (e) {
        this.props.changeToDoComplete(this.props.id, this.props.complete===true ? false : true );
    },
    render: function () {
        return(
            <div className="todo well well-sm">
                <input type="checkbox" checked={ this.props.complete } onChange={ this.handleCheck } />
                {this.props.children}
            </div>
        );
    }
});

var ToDoList = React.createClass({
    render: function () {
        var changeToDoComplete = this.props.changeToDoComplete;
        var todoNodes = this.props.data.map(function (todo) {
            return (
                <ToDoItem id={todo.id} complete={todo.complete} changeToDoComplete={ changeToDoComplete }>{todo.description}</ToDoItem>    
            );
        });
        return (
          <div className="todoList">
            {todoNodes}
          </div>
      );
    }
});

var ToDoForm = React.createClass({
    getInitialState: function() {
        return { description: '' };
    },
    handleDescriptionChange: function (e) {
        this.setState({ description: e.target.value });
    },
    handleSubmit: function(e) {
        e.preventDefault();
        var description = this.state.description.trim();
        if (!description) {
            return;
        }
        this.props.onToDoSubmit({ description: description });
        this.setState({ description: '' });
    },
    render: function () {
        return (
            <form className="todoForm" onSubmit={ this.handleSubmit }>
                <input type="text" 
                       placeholder="To Do"  
                       value={ this.state.description }
                       onChange={ this.handleDescriptionChange }/>
                <input type="submit" value="Post" />
            </form>
        );
    }
})

var ToDo = React.createClass({
    getInitialState: function() {
        return { data: [] };
    },
    componentDidMount: function () {
        $.ajax({
            url: this.props.url,
            dataType: 'json',
            cache: false,
            success: function (data) {
                this.setState({ data: data });
            }.bind(this),
            error: function (xhr, status, err) {
                console.error(this.props.url, status, err.toString());
            }.bind(this)
        });
    },
    handleToDoSubmit: function (todo) {
        $.ajax({
            url: this.props.url,
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            type: 'POST',
            data: JSON.stringify(todo),
            success: function (data) {
                var todos = this.state.data;
                todos.push(data);
                this.setState({ data: todos });
            }.bind(this),
            error: function (xhr, status, err) {
                console.error(this.props.url, status, err.toString());
            }.bind(this)
        });
    },
    changeToDoComplete: function (id, complete) {
        $.ajax({
            url: this.props.url + '/' + id,
            dataType: 'json',
            contentType: 'application/json; charset=utf-8',
            type: 'PUT',
            data: JSON.stringify({ id: id, complete: complete }),
            success: function (data) {
                var todos = this.state.data;
                todos.forEach(function (todo) {
                   if (todo.id == id) { todo.complete = complete }
                });
                this.setState({ data: todos });
            }.bind(this),
            error: function (xhr, status, err) {
                console.error(this.props.url, status, err.toString());
            }.bind(this)    
        });
    },
    render: function () {
        return (
            <div className="todo">
                <h3>To Do</h3>
                <ToDoList data={this.state.data} changeToDoComplete={ this.changeToDoComplete }/>
                <ToDoForm onToDoSubmit={this.handleToDoSubmit} />
            </div>
        );
    }
})

ReactDOM.render(
  <ToDo url="/api/ToDo" />,
  document.getElementById('content')
);