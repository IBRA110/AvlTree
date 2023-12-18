using System.Collections.Generic;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AvlTree
{
    public class AvlTree<T>
    {
        private int Key { get; set; }
        private AvlTree<T>? Left { get; set; }
        private AvlTree<T>? Right { get; set; }
        private int Height { get; set; }
        private int Parent { get; set; }
        private int Sum { get; set; }
        private T Data { get; set; }

        public int Length { get; set; }

        public AvlTree(int key, T data, int parent = -1, AvlTree<T>? left = null, AvlTree<T>? right = null)
        {
            Length = 1;
            Key = key;
            Left = left;
            Right = right;
            Height = 1;
            Parent = parent;
            Sum = key;
            Data = data;
            Length = 1;
        }

        public void Insert(int key, T data)
        {
            if (Key == -1)
            {
                Key = key;
                Sum = key;
                return;
            }
            if (key == Key)
            {
                return;
            }
            if (key < Key)
            {
                if (Left is not null)
                {
                    Left.Insert(key, data);
                }
                else
                {
                    Left = new AvlTree<T>(key, data, Key);
                }
            }
            else
            {
                if (Right is not null)
                {
                    Right.Insert(key, data);
                }
                else
                {
                    Right = new AvlTree<T>(key, data, Key);
                }
            }
            Balance(key);
            Length = UpdateLength();
            Sum = UpdateSum();
        }
        public AvlTree<T>? Delete(int key)
        {
            if (Parent > -1 && Left is not null && Right is null && key == Key) 
            {
                Key = Left.Key;
                Data = Left.Data;
                Left = Left.Left;
                Right = Left.Right;
            } 
            else if (Parent > -1 && Right is not null && Left is null && key == Key) 
            {
                Key = Right.Key;
                Data = Right.Data;
                Left = Right.Left;
                Right = Right.Right;
            } 
            else 
            {
                if (key < Key)
                {
                    if (Left is not null)
                    {
                        Left = Left.Delete(key);
                    }
                }
                else if (key > Key)
                {
                    if (Right is not null)
                    {
                        Right = Right.Delete(key);
                    }
                }
                else
                {
                    if (Left is null && Right is null)
                    {
                        Key = -1;
                        return null;
                    }
                    else if (Left is null)
                    {
                        return Right;
                    }
                    else if (Right is null)
                    {
                        return Left;
                    }

                    if (Right.Height > Left.Height)
                    {
                        int minVal = Right.FindMin();
                        Key = minVal;
                        Right = Right.Delete(minVal);
                    }
                    else if (Right.Height < Left.Height)
                    {
                        int maxVal = Left.FindMax();
                        Key = maxVal;
                        Left = Left.Delete(maxVal);
                    }
                    else
                    {
                        int minVal = Right.FindMin();
                        Key = minVal;
                        Right = Right.Delete(minVal);
                    }
                }
            }

            Balance(key);
            Length = UpdateLength();
            Sum = UpdateSum();
            return this;
        }
        public int FindMax()
        {
            if (Right is null)
            {
                return Key;
            }
            return Right.FindMax();
        }

        public int FindMin()
        {
            if (Left is null)
            {
                return Key;
            }
            return Left.FindMin();
        }
        private void Balance(int key)
        {
            Height = HeightMeter();
            int left_height = 0;
            int right_height = 0;
            if (Right is not null)
            {
                right_height = Right.Height;
            }
                
            if (Left is not null)
            {
                left_height = Left.Height;
            }
            int balance = left_height - right_height;
            
            if (balance > 1 && Key < Left?.Key)
            {
                TurnRight();
                return;
            }
                
            if (balance < -1 && Key > Right?.Key)
            {
                TurnLeft();
                return;
            }
            if (balance > 1 && key < Left?.Key)
            {
                TurnLeftRight();
                return;
            }
                
            if (balance < -1 && Right is not null && key > Right.Key)
            {
                TurnRightLeft();
                return;
            }
        }

        public List<T> InOrder()
        {
            List<T> elements = [];
            if (Left is not null)
            {
                elements.AddRange(Left.InOrder());
            }
            elements.Add(Data);
            if (Right is not null)
            {
                elements.AddRange(Right.InOrder());
            }
            return elements;
        }

        private int UpdateSum()
        {
            int leftSum = 0;
            int rightSum = 0;

            if (Left is not null)
            {
                leftSum = Left.Sum;
            }

            if (Right is not null)
            {
                rightSum = Right.Sum;
            }
            return leftSum + rightSum + Key;
        }
        private int HeightMeter()
        {
            int left_child_height = 0;
            int right_child_height = 0;
            if (Left is not null)
            {
                left_child_height = Left.Height;
            }
            if (Right is not null)
            {
                right_child_height = Right.Height;
            }
            return Math.Max(left_child_height, right_child_height) + 1;
        }
        private void TurnLeft() 
        {
            AvlTree<T> newNode = new(Key, Data, Parent, Left, Right);
            if (Right is null)
            {
                return;
            }
            newNode.Right = Right.Right;
            Key = Right.Key;
            Data = Right.Data;
            Right = Right.Left;
            Left = newNode;

            Left.Parent = Key;
            Left.Height = Left.HeightMeter();
            Left.Length = Left.UpdateLength();
            Left.Sum = Left.UpdateSum();
            Height = HeightMeter();
            Length = UpdateLength();
            Sum = UpdateSum();
            return;
        }
        private void TurnRight()
        {
            AvlTree<T> newNode = new (Key, Data, Parent, Left, Right);
            if (Left is null)
            {
                return;
            }
            newNode.Left = Left.Right;
            Key = Left.Key;
            Data = Left.Data;
            Left = Left.Left;
            Right = newNode;

            Right.Parent = Key;
            Right.Height = Right.HeightMeter();
            Right.Length = Right.UpdateLength();
            Right.Sum = Right.UpdateSum();
            Height = HeightMeter();
            Length = UpdateLength();
            Sum = UpdateSum();
            return;
        }
        private void TurnLeftRight()
        {
            if (Left is null)
            {
                return;
            }
            Left.TurnLeft();
            TurnRight();
            return;
        }
        private void TurnRightLeft()
        {
            Right.TurnRight();
            TurnLeft();
            return;
        }
        
        private int UpdateLength()
        {
            int leftLength = 0;
            int rightLength = 0;
            if (Left is not null) 
            {
                leftLength = Left.Length;
            }

            if (Right is not null) 
            {
                rightLength = Right.Length;
            }

            return leftLength + rightLength + 1;
        }
    }    
}