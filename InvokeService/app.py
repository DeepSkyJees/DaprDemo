from flask import Flask
app = Flask(__name__)

@app.route('/add',methods=['POST'])
@app.route('/Items',methods=['GET'])

def add():
    return "Added"
    
def Items():
    return "Added"

if __name__ == '__main__':
    app.run()
